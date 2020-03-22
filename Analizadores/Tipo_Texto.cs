using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_OLC_1S_2020_201709361.Analizadores
{
    public class Tipo_Texto
    {

        string a;

        public string Tipo_texto(string a)
        {
            string tipo = "";
            this.a = a;
            if ("conj".Equals(a))
            { tipo = "Palabra Reservada"; }



            else { tipo = "ID"; }


            return tipo;
        }

    }
}
