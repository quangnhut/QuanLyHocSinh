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
        List<Class> GetAllClass();
    }
}
