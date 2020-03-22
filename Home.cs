using Proyecto_1_OLC_1S_2020_201709361.Funciones;
using Proyecto_1_OLC_1S_2020_201709361.Objetos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1_OLC_1S_2020_201709361
{
    public partial class Home : Form
    {
        ArrayList ListaPestaña = new ArrayList();
        int contarpestaña = 0;
        public Home()
        {
            InitializeComponent();
        }


        private void CrearPestaña(String Texto_Documento) {

            // crea una pestaña
            TabPage Pestaña = new TabPage("Pestaña" + contarpestaña);
            
            //nombre visible de la pestaña que aparece en la ventana
            Pestaña.Text = "Pestaña " + contarpestaña;
            Pestaña.Name = "Pestaña" + contarpestaña;
            // Textbox que va dentro de la pestaña creada
            RichTextBox Texto = new RichTextBox();

            // dimensiones del texbox 
            Texto.Width = tabControl1.Width;
            Texto.Height = tabControl1.Height;

            // texto del texbox creado en la pestaña
            Texto.Text = Texto_Documento;
            Texto.Name = "texto" + contarpestaña;
            
            // se agrega el texbox a la pestaña
            Pestaña.Controls.Add(Texto);

            // se agrega la pestaña a un arraylist 
            ListaPestaña.Add(Pestaña);

            // se agrega la pestaña al tabcontrol que está por defecto 
            tabControl1.TabPages.Add(Pestaña);
            contarpestaña++;
            tabControl1.SelectedTab = Pestaña;
        
        }

 
        private void EliminarPestañas() {
            TabPage current_tab = tabControl1.SelectedTab;
            ListaPestaña.Remove(current_tab);
            tabControl1.TabPages.Remove(current_tab);
            contarpestaña--;
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void Abrir_Click(object sender, EventArgs e)
        {

            // Se crea un cuadro de dialogo para abrir el archivo, se agrega un filtro para archivos ".er"
            OpenFileDialog Abrir_Documento = new OpenFileDialog();
            Abrir_Documento.RestoreDirectory = true;
            Abrir_Documento.InitialDirectory = "C:\\";
            Abrir_Documento.FilterIndex = 1;
            Abrir_Documento.Filter = "ER Files(*.er)|*.er";
            
            // se hace la verificación para que no crashee
            if (Abrir_Documento.ShowDialog() == DialogResult.OK) {

                // se lee las lineas de texto del archivo escogido
                StreamReader leer = new StreamReader(Abrir_Documento.FileName);
                string line;
                string texto_recopilado ="";
                
                //se une todo el texto en un string 
                while ((line = leer.ReadLine()) != null)
                {
                    texto_recopilado = texto_recopilado + line + "\n";
                }

                // se manda como parametro el texto del archivo para ser mostrado en una pestaña
                CrearPestaña(texto_recopilado);

                Recoleccion_Tokens Holi = new Recoleccion_Tokens();
                ArrayList ho = Holi.recoleccion_Tokens(texto_recopilado).getLista_Tokens();
                string men = "";
                Token example;
                for(int i =0; i<ho.Count;i++)
                {
                    example = (Token)ho[i];
                    men = men + example.getToken() + "         " + example.getTipo()+" "+ '\n' ;

                }
                richTextBox1.Text = men;

                

            }

            
        }
    }
}

