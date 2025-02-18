using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controldeventas
{
    internal class ventas
    {
        private string _Prodcuto;
        private int _cantidad;

        public string Producto
        {
            get { return _Prodcuto; }
            set { _Prodcuto = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public double AsignarPrecio()
        {
            switch (Producto)
            {
                case "Teclado": return 35;
                case "Impresora": return 350;
                case "Monitor": return 550;
                case "Bocinas": return 50;
                case "Mouses": return 20;
            }
            return 0;
        }

        public double CalcularSubTotal()
        {
            return AsignarPrecio() * Cantidad;
        }

        public double CalcularDescuento()
        {
            double subTotal = CalcularSubTotal();

            if (subTotal <= 300) return 5.0 / 100 * subTotal;
            else if (subTotal > 300 && subTotal <= 500) return 10.0 / 100 * subTotal;
            else return 12.5 / 100 * subTotal;

        }

        public double CalcularNeto()
        {
            return CalcularSubTotal() - CalcularDescuento();
        }
    }
}
