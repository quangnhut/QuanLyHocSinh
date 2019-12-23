using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyHocSinh.Models;
using NHibernate.Linq;
using QuanLyHocSinh.Domain;
using QuanLyHocSinh.Service;
using QuanLyHocSinh.IService;
using Castle.Windsor;

namespace QuanLyHocSinh.Controllers
{
    public class ClassController : Controller
    {

        private IClassService iclassservice;

        public ClassController(IClassService service)
        {
            this.iclassservice = service;
        }

       
        //GET: Class
        public ActionResult Index()
        {

            var model = iclassservice.GetAll();  

                List<ClassModel> listclass = new List<ClassModel>();

                for (int i = 0; i < model.Count; i++)
                {
                    var classmodel = ClassModel.ToModel(model[i]);
                    listclass.Add(classmodel);
                }

                ViewBag.Message = "Đây là trang CLASS";
                return View(listclass);
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Class _class)
        {
            try
            {

                iclassservice.Insert(_class);
                
                return RedirectToAction("Index");

            }

            catch (Exception exception)
            {

                return View();

            }
        }


        [HttpGet]
        public ActionResult InsertStudent(int ID)
        {
            var student = iclassservice.AddStudentByClasId(ID);
            return View(student);
        }

        public ActionResult InsertStudent(int ID, Student student)
        {
            try
            {
                student.ClassID = ID;
                iclassservice.InsertStudent(student);

                return RedirectToAction("Index");
            }

            catch (Exception exception)
            {

                return View();

            }
        }


        public ActionResult Edit(int ID)
        {

            var model = iclassservice.Get(ID);
            return View(model);
        }

        [HttpPost]

        public ActionResult Edit(int ID, Class _class)
        {

            try
            {
                var editclass = iclassservice.Update(ID, _class);

                iclassservice.Insert(editclass);

                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {

                return View();

            }
        }

        public ActionResult Delete(int ID)
        {

            var model = iclassservice.Get(ID);
            return View(model);
        }
        [HttpPost]

        public ActionResult Delete(int ID, Class _class)
        {

            try
            {
                iclassservice.Delete(ID, _class);

                return RedirectToAction("Index");

            }

            catch (Exception exception)
            {

                return View();

            }

        }

    }
}