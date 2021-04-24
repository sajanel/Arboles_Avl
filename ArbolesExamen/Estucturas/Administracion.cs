using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolesExamen.Estucturas
{
   public class Administracion:Comparador
    {
        public string nombreMuni { get; set; }  //Nombre del municipio
        public string alfabetoNombre { get; set; } // Ingresa informacion
        public int numeroPrioridad { get; set; } //Ingresa el usuario 1 0 2
        public decimal montoDinero { get; set; }              //Cantidad de dinero
        public int idMuni;
        public int auxClase;

   

        public Administracion()
        {

        }


        public Administracion(int numeroTajeta, string nombre, string apellido,decimal monto) 
        {
            this.nombreMuni = nombre;
            this.alfabetoNombre = apellido;
            this.numeroPrioridad = numeroTajeta;
            this.montoDinero = monto;
            idMuni = 0;
            auxClase = 0;
        }

    //Igual a la tarjeta

        bool Comparador.igualque(object q)
        {
            Administracion Aux = (Administracion)q;
            if (numeroPrioridad == Aux.numeroPrioridad)
                return true;
            else
                return false;           
        }

        bool Comparador.mayorNumero(object q)
        {
            Administracion Aux = (Administracion)q;
            return numeroPrioridad > Aux.numeroPrioridad;

        }

        bool Comparador.menorNumero(object q)
        {
            Administracion Aux = (Administracion)q;
            return numeroPrioridad < Aux.numeroPrioridad;
        }

     
               
      public  bool departamentoMayor(object q)
        {
            MetodoForm(); MetodoClase(q);         
            return idMuni < auxClase;
        }

 
        bool Comparador.departamentoMenor(object q)
        {
            MetodoForm(); MetodoClase(q);
            return idMuni > auxClase;
        }

        bool Comparador.departamentoIgual(object q)
        {
            MetodoForm(); MetodoClase(q);
            return idMuni == auxClase;
        }


        /*    Tira 1 si  La cadena 2 (ord2), se encuentra antes alfabéticamente que la cadena 1 (ord1).
              Tira 0 si  Las dos cadenas se encuentran en el mismo orden alfabético.
              Tira -1 si La cadena 1 (ord1), se encuentra antes alfabéticamente que la cadena 2(ord2).
         */


        public bool nombreAlfabeticoDer(object q)
        {
            Administracion Aux = (Administracion)q;

            if (Aux.alfabetoNombre.CompareTo(alfabetoNombre) == 1)
                return true;
            else
                return false;
        }


        public bool nombreIgualDep(object q)
        {
            Administracion Aux = (Administracion)q;
    
            if (Aux.nombreMuni.CompareTo(nombreMuni) == 0)
                return true;
            else
                return false;

        }

        public bool nombreDiferentDep(object q)
        {
            Administracion Aux = (Administracion)q;
    
            if (Aux.nombreMuni.CompareTo(nombreMuni) != 0)
                return true;
            else
                return false;

        }

        public bool nombreAlfabeticoIzq(object q) 
        {
            Administracion Aux = (Administracion)q;
            if (Aux.alfabetoNombre.CompareTo(alfabetoNombre) == -1)
                return true;
            else
                return false;
        }

        public void MetodoForm()
        {
            if (nombreMuni == "Chiquimula")
            {
                idMuni = 1;
            }
            else if (nombreMuni == "Zacapa")
            {
                idMuni = 2;
            }
            else if (nombreMuni == "El progreso")
            {
                idMuni = 3;
            }
            else if (nombreMuni == "Alta Verapaz")
            {
                idMuni = 4;
            }
            else if (nombreMuni == "Baja Verapaz")
            {
                idMuni = 5;
            }

            else if (nombreMuni == "Guatemala")
            {
                idMuni = 6;
            }
        }


        public void MetodoClase(object q)
        {
            Administracion Aux = (Administracion)q;

            if ("Chiquimula".CompareTo(Aux.nombreMuni) == 0)
            {
                auxClase = 1;
            }
            else if ("Zacapa".CompareTo(Aux.nombreMuni) == 0)
            {
                auxClase = 2;
            }
            else if ("El Progreso".CompareTo(Aux.nombreMuni) == 0)
            {
                auxClase = 3;
            }
            else if ("Alta Verapaz".CompareTo(Aux.nombreMuni) == 0)
            {
                auxClase = 4;
            }
            else if ("Baja Verapaz".CompareTo(Aux.nombreMuni) == 0)
            {
                auxClase = 5;
            }

            else if ("Guatemala".CompareTo(Aux.nombreMuni) == 0)
            {
                auxClase = 6;
            }

        }
        public override string ToString()
        {
            return numeroPrioridad+" "+nombreMuni+" "+alfabetoNombre+" "+montoDinero+"/";
        }
    }
}
