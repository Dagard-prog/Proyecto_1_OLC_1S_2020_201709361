using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_OLC_1S_2020_201709361.Objetos
{
    class Token
    {
        string token;
        int fila;
        int columnma;
        string tipo;

        //-------------------Constructor-----------------------//

        public  Token(string token, int fila, int columna, string tipo){
       
            this.token= token;
            this.fila = fila;
            this.columnma = columna;
            this.tipo =tipo;

        }


        
        //-------------------Funciones-----------------------//

        public void setToken(string token) {
            this.token = token;
        }

        public void setFila(int fila) {
            this.fila = fila;
        }

        public void setColumnma(int columnma) {
            this.columnma = columnma;
        }

        public void setTipo(string tipo) {
            this.tipo = tipo;
        }

        public string getToken() {
            return token;
        }

        public int getFila() {
            return fila;
        }

        public int getColumnma() {
            return columnma;
        }

        public string getTipo() {
            return tipo;
        }


    }
}
