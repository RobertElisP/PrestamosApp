using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class Prestamos
    {
        public double interes { get; set; }
        public double monto { get; set; }
        public int cuota { get; set; }

        public Prestamos(double _interes, double _monto, int _cuota) 
        {
            interes = _interes;
            monto = _monto;
            cuota = _cuota;
        }

        public Prestamos() 
        { 

        }

        public void RealizarPrestamo(Prestamos prestamo) 
        {

            double interes = prestamo.interes / 1200.00;
            double monto = prestamo.monto;
            int plazo = prestamo.cuota;
            DateTime fecha = new DateTime();
            
            double interesMensual = 0;
            double amortizacion = 0;
            double capital = 0;
            int i = 1;
            int Pagos = 0;

            double cuota = monto * (interes / (double)(1 - Math.Pow(1 + (double)interes, -plazo)));


            fecha = DateTime.Now;
            var table = new Table("Cuota", "Fecha Pago", "Cuota", "Capital", "Interes", "Balance");

            Console.Clear();
            Console.WriteLine("Monto del prestamo en RD$: {0}RD$",prestamo.monto);
            Console.WriteLine("Tasa de Porcentaje Anual:  {0}%", prestamo.interes);
            Console.WriteLine("Plazo: {0} Meses",prestamo.cuota);
            Console.WriteLine("Valor Cuota: {0}RD$ ",cuota);
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("");

            for (i = 1; i <= plazo; i++)
            {
                interesMensual = Math.Round((interes * monto), 2);
                monto = Math.Round(monto - cuota + interesMensual, 2);
                capital += Math.Round(cuota - interesMensual,2);
                amortizacion = cuota - interesMensual;

                table.AddRow(Pagos++, fecha.AddMonths(i -1).AddDays(30).ToShortDateString() , cuota,capital, interesMensual,monto);
            }
            table.Print();
        }


        public  Prestamos ObtenerDatosPrestamo()
        {
            Prestamos DatosPrestamos = new Prestamos();
            Console.Write("Monto: ");
            DatosPrestamos.monto = Convert.ToDouble(Console.ReadLine());
            Console.Write("Interes: ");
            DatosPrestamos.interes = Convert.ToDouble(Console.ReadLine());
            Console.Write("Cuota: ");
            DatosPrestamos.cuota = Convert.ToInt32(Console.ReadLine());

            return DatosPrestamos;
        }


    }
}
