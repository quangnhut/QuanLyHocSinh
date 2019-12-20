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

namespace QuanLyHocSinh.Controllers
{
    public class ClassController : Controller
    {

        //GET: Class
        public ActionResult Index()
        {
            //IClassService classservice = new ClassService();
            //List<Class> newlist =  classservice.GetAllClass();

            using (ISession session = NHIbernateSession.OpenSession())
            {
                var classdomain = session.Query<Class>().ToList();
                List<ClassModel> listclass = new List<ClassModel>();

                for (int i = 0; i < classdomain.Count; i++)
                {
                    var classmodel = ClassModel.ToModel(classdomain[i]);
                    listclass.Add(classmodel);
                }

                ViewBag.Message = "Đây là trang CLASS";
                return View(listclass);
            }
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

                using (ISession session = NHIbernateSession.OpenSession())
                {

                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Save(_class);

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

                var _class = session.Get<Class>(ID);

                return View(_class);

            }

        }

        [HttpPost]

        public ActionResult Edit(int ID, Class _class)
        {

            try
            {

                using (ISession session = NHIbernateSession.OpenSession())
                {

                    var classUpdate = session.Get<Class>(ID);


                    classUpdate.Name = _class.Name;

                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Save(classUpdate);

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

                var _class = session.Get<Class>(ID);

                return View(_class);

            }

        }
        [HttpPost]

        public ActionResult Delete(int ID, Class _class)
        {

            try
            {

                using (ISession session = NHIbernateSession.OpenSession())
                {

                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Delete(_class);

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