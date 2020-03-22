using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_OLC_1S_2020_201709361.Objetos
{
    public class Listado_Recoleccion_Tokens
    {

        ArrayList Lista_Tokens = new ArrayList();

        ArrayList Lista_Errores = new ArrayList();


        public Listado_Recoleccion_Tokens(ArrayList Lista1, ArrayList Lista2)
        {
            this.Lista_Errores = Lista2;
            this.Lista_Tokens = Lista1;

        }



        public void setLista_Tokens(ArrayList Lista_Tokens)
        {
            this.Lista_Tokens = Lista_Tokens;
        }

        public void setLista_Errores(ArrayList Lista_Errores)
        {
            this.Lista_Errores = Lista_Errores;
        }

        public ArrayList getLista_Tokens()
        {
            return Lista_Tokens;
        }

        public ArrayList getLista_Errores()
        {
            return Lista_Errores;
        }

    }
}
