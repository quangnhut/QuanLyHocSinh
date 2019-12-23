using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using QuanLyHocSinh.Domain;
using QuanLyHocSinh.IService;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Service
{
    public class StudentService : IStudentService
    {
        ISession session = NHIbernateSession.OpenSession();

        public void Delete(int id, Student deletestudent)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Delete(deletestudent);
            transaction.Commit();
        }

        public Student Get(int id)
        {
            var getstudent = session.Get<Student>(id);
            return getstudent;
        }

        public List<Student> GetAll()
        {
            var studentdomain = session.Query<Student>().ToList();

            return studentdomain;
        }

        public void Insert(Student insertstudent)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(insertstudent);
            transaction.Commit();
        }

        public Student Update(int id, Student _student)
        {
            var studentupdate = session.Get<Student>(id);
            studentupdate.FirstName = _student.FirstName;
            studentupdate.LastName = _student.LastName;
            studentupdate.Code = _student.Code;
            studentupdate.ClassID = _student.ClassID;
            return studentupdate;
        }
    }
}
