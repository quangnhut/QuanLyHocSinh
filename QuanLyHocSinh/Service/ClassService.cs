using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyHocSinh.IService;
using QuanLyHocSinh.Domain;
using NHibernate.Linq;
using NHibernate;
using QuanLyHocSinh.Models;
using FX.Data;
using System.Linq.Expressions;

namespace QuanLyHocSinh.Service
{
    public class ClassService :  IClassService
    {
        ISession session = NHIbernateSession.OpenSession();

        public Student AddStudentByClasId(int id)
        {
            Student student = new Student();
            return student;
        }

        public void Delete(int id, Class deleteclass)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Delete(deleteclass);
            transaction.Commit();
        }

        public Class Get(int id)
        {
            var getclass = session.Get<Class>(id);
            return getclass;
        }

        public List<Class> GetAll()
        {
            var classdomain = session.Query<Class>().ToList();

            return classdomain;
        }

        public List<Class> SearchByName(string name)
        {
            var _class = session.Query<Class>().Where<Class>(c => c.Name == name.ToUpper()).ToList();
            return _class;      
        }

        public void Insert(Class insertclass)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(insertclass);
            transaction.Commit();
        }

        public void InsertStudent(Student student)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(student);
            transaction.Commit();
        }

        public Class Update(int id, Class _class)
        {
            var classupdate = session.Get<Class>(id);
            classupdate.Name = _class.Name;
            return classupdate;
        }
    }
}