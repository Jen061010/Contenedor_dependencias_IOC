using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controlador;
using Servicios;
using Repositorio;
using Ninject;
using Autofac;
using Contenedor_dependencias_clases;


namespace Contenedor_dependencias_clases
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sin reflexion
            Console.WriteLine("Sin reflexion:\n");
            IController controllerSinReflexion = new Controller(new Service(new Repository()));
            controllerSinReflexion.Add();
            
            //Con reflexión
            var controllerType = Type.GetType("Controlador.Controller, Controlador");//GetType ("Namespace.Class, Assembly)
            var serviceType = Type.GetType("Servicios.Service, Servicios");
            var repositoryType = Type.GetType("Repositorio.Repository, Repositorio");

            //Coges el constructor de la clase correspondiente y lo invocas
            var repository = repositoryType.GetConstructors()[0].Invoke(new object[] { });
            var service = serviceType.GetConstructors()[0].Invoke(new object[] { repository });
            var controller = controllerType.GetConstructors()[0].Invoke(new object[] { service });

            Console.WriteLine("Con Reflexion:\n");
            controllerType.GetMethod("Add").Invoke(controller, new object[] { });

            //Con Ninject
            //Hemos agregado a través de Nuget el paquete de Ninject.
            //Y lo utilizamos.... ASÍ SE TRABAJA. Esta configuración no se tendrá que tocar más durate la vida del proyecto.
            //Siempre y cuando no agreguemos nuevos servicios
            Console.WriteLine("\nUtilizanto Ninject\n");
            IKernel kernel = new Ninject.StandardKernel(new ConsoleSaveNinjectModule());
            var controllerNinject = kernel.Get<IController>();
            controllerNinject.Add();
            

            //Con AutoFac
            Console.WriteLine("\nUtilizanto Autofac\n");
            var builder = new ContainerBuilder();
            builder.RegisterType<Service>().As<IService>();
            builder.RegisterType<Controller>().As<IController>();
            builder.RegisterType<Repository>().As<IRepository>();
            
            var container=builder.Build();
            var res=container. Resolve<IController>();
           
            res.Add();
            Console.ReadLine();
        }
    }
}
