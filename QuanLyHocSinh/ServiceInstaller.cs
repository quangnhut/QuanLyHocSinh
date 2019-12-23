using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyHocSinh.IService;
using QuanLyHocSinh.Service;

namespace QuanLyHocSinh
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container,
    Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IClassService>()
                    .ImplementedBy<ClassService>()
                    .LifestyleTransient());

            container.Register(
                Component
                    .For<IStudentService>()
                    .ImplementedBy<StudentService>()
                    .LifestyleTransient());
        }
    }
}
