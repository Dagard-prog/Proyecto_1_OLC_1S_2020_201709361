using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Proyecto_1_OLC_1S_2020_201709361.Objetos;

namespace Proyecto_1_OLC_1S_2020_201709361.Funciones
{

    //Transforma una ER en notación polaca a una ER  en Inorder
    class TransformacionER
    {

        //1 validación 
        string Uno = "Unomas";
        string Cero = "Ceromas";
        string Almenos = "Almenos";

        //2 validaciones
        string Concatenacion = "Concatenacion";
        string Or = "Or";

        //TOKENS QUE DEVUELVEN LAS FUNCIONES
        string Dev_AFN;
        Token Dev_Patron_Graphviz_SCC;
        Token Dev_Patron_Graphviz_SC;

        //tipos 

        string ID = "ID";
        string cadena = "Cadena de texto";

        //Contador 
        int i=0;

        //Validaciones
        bool Validacion_Primera_Vuelta=false;
        bool Validación_Segunda_Vuelta=false;
        public string AFN(ArrayList ER) {

            Token aux;
            Token aux2;
            Token aux3;
            Token añadir_lista_ER;
            ArrayList aux_ER = ER;

            // Se recorre el arraylist que contiene una ER
            for (int i = 0; i < aux_ER.Count; i++) {

               
                aux = (Token)aux_ER[i];

                //Se busca el token que contenga el signo "." o "|" 
                if (aux.getTipo().Equals(Or) | aux.getTipo().Equals(Concatenacion))
                {

                    aux2 = (Token)aux_ER[i + 1];
                    aux3 = (Token)aux_ER[i + 2];

                    //se busca que luego del signo se encuentren dos caracteres(ID o CADENA)
                    if ((aux2.getTipo() == cadena | aux2.getTipo() == ID | aux2.getTipo() == "Patron") && (aux3.getTipo() == cadena | aux3.getTipo() == ID|aux3.getTipo() == "Patron"))
                    {

                        //Se genera un nuevo Token que contiene un AFN guardado en un string 
                        añadir_lista_ER = Patron_SCC(aux.getToken(), aux2, aux3);

                        //Se eliminan de la lista los tokens que están en la posición i,  i+1 e i+2
                        aux_ER.Remove(i + 2);
                        aux_ER.Remove(i + 1);
                        aux_ER.Remove(i);

                        //Se reemplaza en la posición de i el token del signo por el nuevo token con el AFN, el tipo del token es"Cadena de texto"
                        aux_ER.Insert(i, añadir_lista_ER);

                    }

                }

                //Se busca el token que contenga el signo "?" o "+" o "*" 
                else if (aux.getTipo().Equals(Uno) | aux.getTipo().Equals(Almenos) | aux.getTipo().Equals(Cero)) {

                    aux2 = (Token)aux_ER[i + 1];

                    //se busca que luego del signo se encuentren el caracteres(ID o CADENA)
                    if (aux2.getTipo() == cadena | aux2.getTipo() == ID| aux2.getTipo() == "Patron")
                    {

                        //Se genera un nuevo Token que contiene un AFN guardado en un string 
                        añadir_lista_ER = Patron_SC(aux.getToken(), aux2);

                        //Se eliminan de la lista los tokens que están en la posición i e i+1
                        aux_ER.Remove(i + 1);
                        aux_ER.Remove(i);

                        //Se reemplaza en la posición de i el token del signo por el nuevo token con el AFN, el tipo del token es"Cadena de texto"
                        aux_ER.Insert(i, añadir_lista_ER);



                    }

                }


            }




            return Dev_AFN;

        }

        //Devuelve patrones de concatenación o de "Or" del AFN 
        public Token Patron_SCC(string signo, Token caracter_1, Token caracter_2) {

            //texto que tendrá el patrón de la estructura en código de graphviz
            string aux="";

            if (signo.Equals(Concatenacion)) {

                aux = "L" + i + " -> " + "L" + (i + 1) + "[label=\"" + caracter_1.getToken() + "\"];"+"\n"+
                      "L" + (i+1) + " -> " + "L" + (i + 2) + "[label=\"" + caracter_2.getToken() + "\"];" + "\n";
                
                Dev_Patron_Graphviz_SCC.setFila(i);
                Dev_Patron_Graphviz_SCC.setColumnma(i + 2);
                i = i + 3;
                          
            }

            else if (signo.Equals(Or)) {

                aux = "L" + i + " -> " + "L" + (i + 1) + "[label=\" Ɛ \"];" + "\n" +
                      "L" + (i + 1) + " -> " + "L" + (i + 2) + "[label=\"" + caracter_1.getToken() + "\"];" + "\n" +
                      "L" + (i + 2) + " -> " + "L" + (i + 5) + "[label=\" Ɛ \"];" + "\n" +


                      "L" + i + " -> " + "L" + (i + 3) + "[label=\" Ɛ \"];" + "\n" +
                      "L" + (i + 3) + " -> " + "L" + (i + 4) + "[label=\"" + caracter_2.getToken() + "\"];" + "\n" +
                      "L" + (i + 4) + " -> " + "L" + (i + 5) + "[label=\" Ɛ \"];" + "\n";

                Dev_Patron_Graphviz_SCC.setFila(i);
                Dev_Patron_Graphviz_SCC.setColumnma(i + 5);
                i = i + 6;


            }
            //el patrón generado según el signo que entró se guarda en un token para luego ser devuelto
            Dev_Patron_Graphviz_SCC.setToken(aux);
            Dev_Patron_Graphviz_SCC.setTipo("Patron");

            return Dev_Patron_Graphviz_SCC;
        }


        public Token Patron_SC(string signo, Token caracter_1)
        {

            //texto que tendrá el patrón de la estructura en código de graphviz
            string aux = "";

            if (signo.Equals(Almenos))
            {

                aux = "L" + i + " -> " + "L" + (i + 1) + "[label=\" Ɛ \"];" + "\n" +
                      "L" + (i + 1) + " -> " + "L" + (i + 2) + "[label=\"" + caracter_1.getToken() + "\"];" + "\n" +
                      "L" + (i + 2) + " -> " + "L" + (i + 3) + "[label=\" Ɛ \"];" + "\n" +

                      "L" + i + " -> " + "L" + (i + 3) + "[label=\" Ɛ \"];" + "\n";
                
                Dev_Patron_Graphviz_SC.setFila(i);
                Dev_Patron_Graphviz_SC.setColumnma(i + 3);
                i = i + 4;

            }

            else if (signo.Equals(Uno))
            {

                aux = "L" + i + " -> " + "L" + (i + 1) + "[label=\" Ɛ \"];" + "\n" +
                      "L" + (i + 1) + " -> " + "L" + (i + 2) + "[label=\"" + caracter_1.getToken() + "\"];" + "\n" +
                      "L" + (i + 2) + " -> " + "L" + (i + 3) + "[label=\" Ɛ \"];" + "\n" +
                      "L" + (i + 3) + " -> " + "L" + (i + 4) + "[label=\"" + caracter_1.getToken() + "\"];" + "\n" +

                      "L" + (i + 2) + " -> " + "L" + (i + 1) + "[label=\" Ɛ \"];" + "\n"+
                      "L" + (i)     + " -> " + "L" + (i + 3) + "[label=\" Ɛ \"];" + "\n";

                Dev_Patron_Graphviz_SC.setFila(i);
                Dev_Patron_Graphviz_SC.setColumnma(i + 4);
                i = i + 5;

            }

            else if (signo.Equals(Cero))
            {

                aux = "L" + i + " -> " + "L" + (i + 1) + "[label=\" Ɛ \"];" + "\n" +
                      "L" + (i + 1) + " -> " + "L" + (i + 2) + "[label=\"" + caracter_1.getToken() + "\"];" + "\n" +
                      "L" + (i + 2) + " -> " + "L" + (i + 3) + "[label=\" Ɛ \"];" + "\n" +


                      "L" + (i + 2) + " -> " + "L" + (i + 1) + "[label=\" Ɛ \"];" + "\n" +
                      "L" + (i) + " -> " + "L" + (i + 3) + "[label=\" Ɛ \"];" + "\n";

                Dev_Patron_Graphviz_SC.setFila(i);
                Dev_Patron_Graphviz_SC.setColumnma(i + 3);
                i = i + 4;

            }

            //el patrón generado según el signo que entró se guarda en un token para luego ser devuelto
            Dev_Patron_Graphviz_SC.setToken(aux);
            Dev_Patron_Graphviz_SC.setTipo("Patron");

            return Dev_Patron_Graphviz_SC;
        }





    }
}
