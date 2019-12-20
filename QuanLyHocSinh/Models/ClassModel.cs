using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iesi.Collections.Generic;
using System.Collections.ObjectModel;
using QuanLyHocSinh.Domain;

namespace QuanLyHocSinh.Models
{
    public class ClassModel
    {
        //public virtual int ID { get; set; }
        //public virtual string Name { get; set; }
        //public virtual ISet<Student> Students { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public ISet<QuanLyHocSinh.Domain.Student> Students { get; set; }

        public Class ToEntity(Class tmp)
        {
            tmp.Name = this.Name;
            return tmp;
        }

        public static ClassModel ToModel(Class entity)
        {
            return new ClassModel()
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

    }
}