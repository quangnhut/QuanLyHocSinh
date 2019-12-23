using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyHocSinh.Domain;

namespace QuanLyHocSinh.Models
{
    public class StudentModel
    {
        //public virtual int ID { get; set; }
        //public virtual string FirstName { get; set; }
        //public virtual string LastName { get; set; }
        //public virtual string Code { get; set; }
        //public virtual int ClassID { get; set; }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public int ClassID { get; set; }

        public Student ToEntity(Student tmp)
        {
            tmp.FirstName = this.FirstName;
            tmp.LastName = this.LastName;
            tmp.Code = this.Code;
            tmp.ClassID = this.ClassID;

            return tmp;
        }

        public static StudentModel ToModel(Student entity)
        {
            return new StudentModel()
            {
                ID = entity.ID,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Code = entity.Code,
                ClassID = entity.ClassID
            };
        }

        public Class GetClassById(int id)
        {

            using (ISession session = NHIbernateSession.OpenSession())
            {
                var getclassname = session.Query<Class>().FirstOrDefault<Class>(c => c.ID == id);
                return getclassname;
            }
        }

    }

}