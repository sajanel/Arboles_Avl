using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolesExamen.Estucturas
{
  public class Nodo
    {
        public  Object dato;
        public Nodo izdo;
        public Nodo dcho;


        public Nodo(Object valor)
        {
            dato = valor;
            izdo = dcho = null;
        }

        public Nodo(Nodo ramaIzdo, Object valor, Nodo ramaDcho)
        {
            this.dato=valor;
            izdo = ramaIzdo;
            dcho = ramaDcho;
        }

        // operaciones de acceso
        public Object valorNodo()
        { 
            return dato;
        }

        public Nodo subarbolIzdo() { return izdo; }
        public Nodo subarbolDcho() { return dcho; }


        public void nuevoValor(Object d) 
        {
            dato = d; 
        }


        public void ramaIzdo(Nodo n) { izdo = n; }
        public void ramaDcho(Nodo n) { dcho = n; }
        
       public string visitar()
        {
            return dato.ToString();
        }

    }

    }

