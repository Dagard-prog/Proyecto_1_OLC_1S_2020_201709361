using Proyecto_1_OLC_1S_2020_201709361.Analizadores;
using Proyecto_1_OLC_1S_2020_201709361.Objetos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1_OLC_1S_2020_201709361.Funciones
{
    public class Recoleccion_Tokens
    {


        ArrayList Tkns = new ArrayList();
        ArrayList Trunks = new ArrayList();
        string Llave_Inicial = "{";
        string Llave_Final = "}";
        string Dos_Puntos = ":";
        string Comilla_doble = "\"";
        string Igual = "=";
        string Punto_Coma = ";";
        string tipo_comillas = "Cadena de texto";





        //codigo completo
        string concatenador = "";


        //VARIABLES RECOPILACION_TOKENS

        int aumento_f = 1;
        int aumento_c = 1;
        int estadoprincipal = 0;
        string nombre_lista;
        int repeticion = 1;
        int contador = 0;
        string tipo;
        //variables analizar
        string token = "";
        string token1 = "";
        string num = "";
        int i;
        int j;
        int a;
        Boolean Cadena_valida;

        Analizador analizador = new Analizador();
        Tipo_Signo tipo_token = new Tipo_Signo();
        Tipo_Texto tipo_texto = new Tipo_Texto();

        // solicita un texto como parametro para realizar la recoleccion de tokens;
        // devuelve un objeto con dos listados de tokens "objeto( lista 1, lista2 )"
        // lista 1 = lista de tokens
        // lista 2 = lista de errores
        public  Listado_Recoleccion_Tokens recoleccion_Tokens(string TextBox)
        {

            string[] texto1;
            string caja1 = TextBox;
            texto1 = caja1.Split('\n');
            

            for (i = 0; i < texto1.Length; i++)
            {

                char[] a;
                a = texto1[i].Trim().ToCharArray();
                int f = i + 1;
                for (j = 0; j < a.Length; j++)
                {
                    int c = j + 1;


                    switch (estadoprincipal)
                    {

                        case 0:

                            //espacios en blanco
                            if (a[j] == ' ')
                            {
                                break;
                            }

                            /*
                            Comentario

                            Analiza si viene el lexema "//", si viene continua juntando texto hasta encontrar salto de linea en case 1
                            si no viene se reinicia el token, se guarda el error e inicial el swich otra vez

                            Case 1

                            */

                            else if (analizador.slash(a[j]))
                            {


                                string aux = Char.ToString(a[j]);
                                string aux1 = Char.ToString(a[j + 1]);
                                token = aux + aux1;

                                if (!"/".Equals(aux))
                                {
                                    tipo = "Signo Léxico Desconocido, se esperaba \"//\"";
                                    Token guardar = new Token(token, f, c + 1, tipo);
                                    Trunks.Add(guardar);
                                    token = "";
                                    estadoprincipal = 0;
                                }
                                else
                                {

                                    estadoprincipal = 1;
                                }

                                j = j + 1;
                                break;

                            }

                            /*
                            ID o Palabra Reservada

                            Se analiza si viene un caracter alfanumerico o guiones, si esto es correcto se procede a concatenar y se mueve al case 2
                            sino se guarda el error y se reinica el proceso

                            Case 2
                            */
                            else if (analizador.Alfabeto_con_guiones(a[j]))
                            {

                                token = token + Char.ToString(a[j]);
                                estadoprincipal = 2;
                                break;

                            }

                            /*
                            Texto de la forma "----"

                            Si viene comillas se procede al case 3 para concatenar todo hasta que aparezca otra vez el signo inicial

                            Case 3
                            */
                            else if (analizador.Comillas(a[j]))
                            {

                                token = token + Char.ToString(a[j]);
                                estadoprincipal = 3;
                                break;

                            }


                            /*
                            signo de asignacion : "->"
                            Revisa si viene el signo comparando dos caracteres seguidos y si viene, lo guarda, sino reinicia el proceso
                            */
                            else if (analizador.menos(a[j]))
                            {

                                token = Char.ToString(a[j]) + Char.ToString(a[j + 1]);
                                tipo = tipo_token.Tipo_Signo_Analizado(token);
                                Token guardar = new Token(token, f, c, tipo);
                                Tkns.Add(guardar);
                                token = "";
                                j = j + 1;

                                estadoprincipal = 0;

                                break;
                                //se revisa si lo que viene es un conjunto o una expresión, esto se valida

                            }

                            else if (analizador.menor_que(a[j]) && analizador.admiracion(a[j + 1]))
                            {

                                token = Char.ToString(a[j]) + Char.ToString(a[j + 1]);
                                estadoprincipal = 4;
                                j = j + 1;

                                break;


                            }


                            /*
                            Signos del abecedario

                            Analiza si el caracter ingresado pertenece a los simbolos permitidos
                            Si es correcto se guarda, si es incorrecto se guarda el error
                            Se reinicia todo el proceso luego de esto en Case 0

                            Case 0
                            */
                            else if (analizador.Cualquier_Signo(a[j]))
                            {

                                token = token + Char.ToString(a[j]);

                                tipo = tipo_token.Tipo_Signo_Analizado(token);


                                Token guardar = new Token(token, f, c, tipo);

                                if ("Signo Léxico Desconocido".Equals(tipo))
                                {
                                    Trunks.Add(guardar);

                                }
                                else
                                {

                                    Tkns.Add(guardar);
                                }

                                estadoprincipal = 0;
                                token = "";
                                break;

                            }



                            /*
                            Inicio de comentario multilinea : "<!"
                            Revisa si viene el signo comparando dos caracteres seguidos y si viene, empieza la unión del comentario multilinea, sino reinicia el proceso
                            */

                            break;

                        //finalizador case 0

                        /*
                        Case 1
                        Este case une los comentarios de una linea
                        */
                        case 1:
                            // si detecta un espacio o un salto de linea deja de juntar caracteres, guarda el token y cambia de estado
                            if (c > 2)
                            {

                                token = token + Char.ToString(a[j]);
                                estadoprincipal = 1;

                            }
                            else
                            {

                                tipo = "comentario";
                                Token guardar = new Token(token, f, c, tipo);
                                Tkns.Add(guardar);
                                token = "";
                                estadoprincipal = 0;
                                j = j - 1;

                            }
                            break;

                        /*
                        Case 2
                        Alfabeto del tipo L(L|D|-|_)*
                        */
                        case 2:

                            if (analizador.Alfabeto_con_guiones(a[j]) | analizador.Numerico(a[j]) | a[j] == '_')
                            {
                                token = token + Char.ToString(a[j]);
                                estadoprincipal = 2;
                            }

                            else
                            {

                                string aux = token;
                                token = token.ToLower();
                                tipo = tipo_texto.Tipo_texto(token);

                                estadoprincipal = 0;

                                Token guardar = new Token(token, f, c - 1, tipo);
                                Tkns.Add(guardar);
                                token = "";
                                j = j - 1;
                                c = c - 1;

                            }




                            //finalizador case 2
                            break;

                        /*
                        Case 3
                        comillas
                        */
                        case 3:
                            if (!"\"".Equals(Char.ToString(a[j])))
                            {
                                token = token + Char.ToString(a[j]);


                            }

                            else
                            {
                                token = token + Char.ToString(a[j]);
                                tipo = tipo_comillas;
                                estadoprincipal = 0;
                                Token guardar = new Token(token, f, c, tipo);
                                //System.out.println(Cadena);
                                Tkns.Add(guardar);
                                token = "";

                            }

                            break;

                        /*
                        Case 4
                        Comentario Multilinea
                        */

                        case 4:

                            if (a[j] == '!')
                            {

                                token = token + Char.ToString(a[j]) + Char.ToString(a[j + 1]);


                                if (a[j + 1] != '>')
                                {
                                    Token guardar = new Token(token, f, c, tipo);
                                    tipo = "Error Léxico, se esperaba cierre de comentario(!>) ";
                                    Trunks.Add(guardar);

                                }
                                else
                                {
                                    Token guardar = new Token(token, f, c, tipo);
                                    tipo = "Comentario MultiLinea";
                                    Tkns.Add(guardar);
                                }

                                estadoprincipal = 0;
                            }

                            else
                            {
                                token = token + Char.ToString(a[j]);
                                estadoprincipal = 4;


                            }

                            break;

                    }



                }

                aumento_f++;
            }
            Listado_Recoleccion_Tokens Listado_Doble = new Listado_Recoleccion_Tokens(Tkns, Trunks);
            return Listado_Doble;
        }


    }
}
