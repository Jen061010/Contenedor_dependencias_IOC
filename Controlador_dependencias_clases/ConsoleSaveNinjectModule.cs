using Controlador;
using Ninject.Modules;
using Repositorio;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contenedor_dependencias_clases
{
    public class ConsoleSaveNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IService>().To<Servicios.Service>();
            this.Bind<IRepository>().To<Repositorio.Repository>();
            this.Bind<IController>().To<Controlador.Controller>();

        }
    }
}
