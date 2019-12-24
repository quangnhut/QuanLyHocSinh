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
        public ActionResult Index(string key)
        {
            var model = istudentservice.GetAll();
                ViewBag.Message = "STUDENT PAGE";
                List<StudentModel> liststudent = new List<StudentModel>();
                for (int i=0; i< model.Count; i++)
                {
                    var studentmodel = StudentModel.ToModel(model[i]);
                    liststudent.Add(studentmodel);
                }

            if (key == "")
            {
                return View(liststudent);
            }
            else if (key != null)
            {
                var studentdomain = istudentservice.SearchAll(key);
                List<StudentModel> studentmodelsearch = new List<StudentModel>();
                for (int i = 0; i < studentdomain.Count; i++)
                {
                    var studentmodel = StudentModel.ToModel(studentdomain[i]);
                    studentmodelsearch.Add(studentmodel);
                }
                return View(studentmodelsearch);
            }



            return View(liststudent);
            
        }


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