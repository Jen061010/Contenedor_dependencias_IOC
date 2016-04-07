using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Repository:IRepository
    {
        public Repository()
        {
        }
        public void Add()
        {
            Console.WriteLine("Add");
        }
    }
}
