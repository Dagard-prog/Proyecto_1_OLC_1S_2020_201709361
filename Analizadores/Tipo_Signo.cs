using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_OLC_1S_2020_201709361.Analizadores
{
    public class Tipo_Signo
    {


        string a;


        string Flecha = "->";
        string Signo_Comentario = "//";
        string Llave_Inicial = "{";
        string Llave_Final = "}";
        string Inicio_Comentario_MultiL = "<!";
        string Final_Comentario_MultiL = "<!";
        string Punto_Coma = ";";
        string Dos_Puntos = ":";
        string Doble_Porcentaje = "%%";
        string Coma = ",";
        string Punto = ".";
        string Cero_o_Mas = "*";
        string Uno_o_Mas = "+";








        public string Tipo_Signo_Analizado(string a)

        {
            this.a = a;
            string tipo = "";

            if (a.Equals(Inicio_Comentario_MultiL) | a.Equals(Final_Comentario_MultiL))
            {
                tipo = "Comentario Multilinea";
            }

            else if (a.Equals(Llave_Final) | a.Equals(Llave_Inicial))
            {
                tipo = "Llaves";
            }

            else if (a.Equals(Signo_Comentario))
            {
                tipo = "Comentario";
            }

            else if (a.Equals(Flecha))
            {
                tipo = "Signo de Asignación";
            }


            else if (a.Equals(Punto_Coma) | a.Equals(Dos_Puntos))
            {
                tipo = "Punto y coma y dos puntos";
            }

            else if (a.Equals(Doble_Porcentaje))
            {
                tipo = "Doble Porcentaje";
            }

            else if (a.Equals(Punto))
            {
                tipo = "Punto";
            }

            else if (a.Equals(Coma))
            {
                tipo = "Coma";
            }

            else if (a.Equals(Cero_o_Mas))
            {
                tipo = "Cero o más";
            }

            else if (a.Equals(Uno_o_Mas))
            {
                tipo = "Uno o más";
            }


            else { tipo = "Signo Léxico Desconocido"; }

            return tipo;
        }




    }

}
