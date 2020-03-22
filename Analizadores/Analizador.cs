using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_OLC_1S_2020_201709361.Analizadores
{
    public class Analizador
    {

        char a;

        public Boolean menos(char a)
        {
            Boolean Validacion = false;
            this.a = a;
            if (a == 45 | a == 196 | a == '-')
            {
                Validacion = true;

            }

            return Validacion;
        }

        public Boolean admiracion(char a)
        {

            Boolean Validacion = false;
            this.a = a;
            if (a == '!')
            {
                Validacion = true;

            }

            return Validacion;

        }

        public Boolean mayor_que(char a)
        {
            Boolean Validacion = false;
            this.a = a;
            if (a == '>')
            {
                Validacion = true;

            }

            return Validacion;
        }

        public Boolean Numerico(char a)
        {
            Boolean Validacion = false;
            this.a = a;

            for (int i = 48; i <= 57; i++)
            {
                if (a == i)
                {
                    i = 57;
                    Validacion = true;


                }

            }

            return Validacion;

        }

        public Boolean slash(char a)
        {
            Boolean Validacion = false;
            this.a = a;
            if (a == '/')
            {
                Validacion = true;

            }

            return Validacion;
        }

        public Boolean menor_que(char a)
        {
            Boolean Validacion = false;
            this.a = a;
            if (a == '<')
            {
                Validacion = true;

            }

            return Validacion;
        }

        public Boolean dos_puntos(char a)
        {
            Boolean Validacion = false;
            this.a = a;
            if (a == '<')
            {
                Validacion = true;

            }

            return Validacion;
        }

        public Boolean punto_coma(char a)
        {
            Boolean Validacion = false;
            this.a = a;
            if (a == '<')
            {
                Validacion = true;

            }

            return Validacion;
        }


        public Boolean Alfabeto_con_guiones(char a)
        {
            Boolean Validacion = false;
            this.a = a;


            //A~Z
            for (int i = 65; i <= 90; i++)
            {
                if (a == i)
                {
                    i = 91;
                    Validacion = true;


                }

            }
            //a~z
            for (int i = 97; i <= 122; i++)
            {
                if (a == i)
                {
                    i = 123;
                    Validacion = true;


                }

            }

            //vocales tildadas, "ñ", "Ñ"
            for (int i = 160; i <= 165; i++)
            {
                if (a == i)
                {
                    i = 166;
                    Validacion = true;


                }

            }

            //vocales mayusculas tildadas
            if (a == 'á' | a == 'Ñ' | a == 'ñ' | a == 130 | a == 181 | a == 144 | a == 224 | a == 214)
            { Validacion = true; }
            return Validacion;

        }
        // 47 = /    [ = 91

        public Boolean Cualquier_Signo(char a)
        {
            Boolean Validacion = false;
            this.a = a;

            for (int i = 33; i <= 47; i++)
            {
                if (i != 34 | i != 37 | i != 47)
                {
                    if (a == i)
                    {
                        i = 58;
                        Validacion = true;


                    }
                }

            }

            for (int i = 58; i <= 64; i++)
            {

                if (i != 62 | i != 60)
                {

                    if (a == i)
                    {
                        i = 65;
                        Validacion = true;


                    }

                }


            }

            for (int i = 91; i <= 96; i++)
            {
                if (a == i)
                {
                    i = 97
;
                    Validacion = true;


                }

            }

            for (int i = 123; i <= 126; i++)
            {
                if (a == i)
                {
                    i = 127
;
                    Validacion = true;


                }

            }

            if (a == 238 | a == 239)
            { Validacion = true; }


            return Validacion;

        }

        public Boolean Comillas(char a)
        {
            Boolean Validacion = false;
            this.a = a;



            if (a == 34)
            { Validacion = true; }
            return Validacion;

        }

    }
}
