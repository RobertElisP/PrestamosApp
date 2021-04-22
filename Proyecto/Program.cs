using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class Program
    {



        static void Main(string[] args)
        {
            
            Prestamos d = new Prestamos();
            var datosPrestamos = d.ObtenerDatosPrestamo();
            d.RealizarPrestamo(datosPrestamos);
            Console.ReadKey();

        }
    }
}
