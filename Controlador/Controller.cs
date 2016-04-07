using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios;
using Repositorio;


namespace Controlador
{
    public class Controller:IController
    {
        readonly IService _service;
     
        public Controller(IService service)
        {
            if (null == service)
            {
                throw new ArgumentNullException("service");
            }
            _service = service;
        }

        public void Add()
        {
            _service.Add();
        }
       
    }
}
