using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyHocSinh.IService;
using QuanLyHocSinh.Domain;

namespace QuanLyHocSinh.Service
{
    public class ClassService : IClassService
    {
        public List<Class> GetAllClass()
        {
            List<Class> list = new List<Class>();
            list.Add(new Class { Name = "LOP05" });
            list.Add(new Class { Name = "LOP04" });
            return list;
        }
    }
}