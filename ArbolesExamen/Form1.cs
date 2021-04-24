using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ArbolesExamen.Estucturas;
using System.IO;
namespace ArbolesExamen
{
    public partial class Form1 : Form
    {
        ArbolAVL miArbolCliente = new ArbolAVL();
        ArbolBinario miArbol = new ArbolBinario();
        Administracion Admin;
   
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            Admin = new Administracion(Convert.ToInt32(txtPrioridad.Text), comboBox1.Text, txtNombre.Text, Convert.ToDecimal(txtMonto.Text));
            miArbolCliente.insertar(Admin);

            StreamWriter escribirDato = new StreamWriter("miArchivo.txt", false);
            string nuevo = ArbolAVL.preorden(miArbolCliente.raizArbol());
            string[] palabras = nuevo.Split('/');
         
          //   TextWriter escribirDato = new StreamWriter("Temp.txt",false);
            listBox1.Items.Clear();

            foreach (string words in palabras)
            {      
                    escribirDato.WriteLine(words);
                    listBox1.Items.Add(words);
            }
            escribirDato.Close();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
          
                Administracion objetoBuscado = new Administracion();
                objetoBuscado.nombreMuni = comboBox1.Text;

                if (miArbolCliente.buscar(objetoBuscado)!=null)
                {
                Nodo c1 = miArbolCliente.buscar(objetoBuscado);
                objetoBuscado = (Administracion)c1.dato;

                MessageBox.Show(c1.dato.ToString());
                }

                else { MessageBox.Show("No esta registrado aun");}

          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
