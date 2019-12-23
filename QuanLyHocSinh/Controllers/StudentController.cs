using NHibernate;
using NHibernate.Linq;
using QuanLyHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyHocSinh.Domain;
using QuanLyHocSinh.IService;

namespace QuanLyHocSinh.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService istudentservice;
        public StudentController(IStudentService service)
        {
            this.istudentservice = service;
        }
        // GET: Student
        public ActionResult Index()
        {
            var model = istudentservice.GetAll();
                ViewBag.Message = "Đây là trang STUDENT";
                List<StudentModel> liststudent = new List<StudentModel>();
                for (int i=0; i< model.Count; i++)
                {
                    var studentmodel = StudentModel.ToModel(model[i]);
                    liststudent.Add(studentmodel);
                }
                return View(liststudent);
            
        }

        //public ActionResult Create()
        //{

        //    return View();

        //}

        //[HttpPost]

        //public ActionResult Create(Student student)
        //{

        //    try
        //    {
        //        istudentservice.Insert(student);

        //        return RedirectToAction("Index");
        //    }

        //    catch (Exception exception)
        //    {

        //        return View();

        //    }

        //}

        public ActionResult Edit(int ID)
        {

            var model = istudentservice.Get(ID);
            return View(model);
        }

        [HttpPost]

        public ActionResult Edit(int ID, Student student)
        {

            try
            {
                var editstudent = istudentservice.Update(ID, student);

                istudentservice.Insert(editstudent);

                return RedirectToAction("Index");

            }

            catch
            {

                return View();

            }


        }


        public ActionResult Delete(int ID)
        {
            var model = istudentservice.Get(ID);
            return View(model);

        }
        [HttpPost]

        public ActionResult Delete(int ID, Student student)
        {

            try
            {
                istudentservice.Delete(ID, student);

                return RedirectToAction("Index");

            }

            catch (Exception exception)
            {

                return View();

            }

        }

    }

}