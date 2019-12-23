using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinh.Domain;

namespace QuanLyHocSinh.IService
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student Get(int id);
        Student Update(int id, Student _student);
        void Insert(Student insertstudent);
        void Delete(int id, Student deletestudent);
    }
}
