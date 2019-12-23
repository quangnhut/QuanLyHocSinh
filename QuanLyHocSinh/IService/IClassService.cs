using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinh.Domain;

namespace QuanLyHocSinh.IService
{
    public interface IClassService
    {
        List<Class> GetAll();
        Class Get(int id);
        Class Update(int id, Class _class);
        void Insert(Class insertclass);
        void Delete(int id, Class deleteclass);
        Student AddStudentByClasId(int id);
        void InsertStudent(Student student);
    }
}
