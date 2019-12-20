using NHibernate;
using NHibernate.Linq;
using QuanLyHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyHocSinh.Domain;

namespace QuanLyHocSinh.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (ISession session = NHIbernateSession.OpenSession())
            {
                var students = session.Query<Student>().ToList();
                ViewBag.Message = "Đây là trang STUDENT";
                List<StudentModel> liststudent = new List<StudentModel>();
                for (int i=0; i< students.Count; i++)
                {
                    var studentmodel = StudentModel.ToModel(students[i]);
                    liststudent.Add(studentmodel);
                }
                return View(liststudent);
            }
        }

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]

        public ActionResult Create(Student student)
        {

            try
            {

                using (ISession session = NHIbernateSession.OpenSession())
                {

                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Save(student);

                        transaction.Commit();

                    }

                }

                return RedirectToAction("Index");

            }

            catch (Exception exception)
            {

                return View();

            }

        }

        public ActionResult Edit(int ID)
        {

            using (ISession session = NHIbernateSession.OpenSession())
            {

                var student = session.Get<Student>(ID);

                return View(student);

            }


        }

        [HttpPost]

        public ActionResult Edit(int ID, Student student)
        {

            try
            {

                using (ISession session = NHIbernateSession.OpenSession())
                {

                    var studentUpdate = session.Get<Student>(ID);


                    studentUpdate.FirstName = student.FirstName;

                    studentUpdate.LastName = student.LastName;

                    studentUpdate.Code = student.Code;

                    studentUpdate.ClassID = student.ClassID;


                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Save(studentUpdate);

                        transaction.Commit();


                    }

                }

                return RedirectToAction("Index");

            }

            catch
            {

                return View();

            }


        }


        public ActionResult Delete(int ID)
        {

            using (ISession session = NHIbernateSession.OpenSession())
            {

                var student = session.Get<Student>(ID);

                return View(student);

            }

        }
        [HttpPost]

        public ActionResult Delete(int ID, Student student)
        {

            try
            {

                using (ISession session = NHIbernateSession.OpenSession())
                {

                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Delete(student);

                        transaction.Commit();

                    }

                }

                return RedirectToAction("Index");

            }

            catch (Exception exception)
            {

                return View();

            }

        }

    }

}