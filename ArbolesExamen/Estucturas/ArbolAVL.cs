using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolesExamen.Estucturas
{
  public class ArbolAVL:ArbolBinario
    {
         protected NodoAvl raiz;

        public ArbolAVL()
        {
            raiz = null;
        }

        public NodoAvl raizArbol()
        {
            return raiz;
        }



        private NodoAvl rotacionII(NodoAvl n, NodoAvl n1)
        {
            n.ramaIzdo(n1.subarbolDcho());
            n1.ramaDcho(n);
            // actualización de los factores de equilibrio
            if (n1.fe == -1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = -1;
                n1.fe = 1;
            }
            return n1;
        }


        private NodoAvl rotacionDD(NodoAvl n, NodoAvl n1)
        {
            n.ramaDcho(n1.subarbolIzdo());
            n1.ramaIzdo(n);
            // actualización de los factores de equilibrio
            if (n1.fe == +1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = +1;
                n1.fe = -1;
            }
            return n1;
        }


        private NodoAvl rotacionID(NodoAvl n, NodoAvl n1)
            {
            NodoAvl n2;
            n2 = (NodoAvl) n1.subarbolDcho();
            n.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n);
            n1.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;
            if (n2.fe == -1)
                n.fe = 1;
            else
                n.fe = 0;
            n2.fe = 0;
            return n2;
            }


        private NodoAvl rotacionDI(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.subarbolIzdo();
            n.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n);
            n1.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n.fe = -1;
            else
                n.fe = 0;
            if (n2.fe == -1)
                n1.fe = 1;
            else
                n1.fe = 0;
            n2.fe = 0;
            return n2;
        }



        public void insertar (Object valor)//throws Exception
            {
            Comparador dato;
            Logical h = new Logical(false); // intercambia un valor booleano
            dato = (Comparador) valor;
            raiz = insertarAvl(raiz, dato, h);
            }

            private NodoAvl insertarAvl(NodoAvl raiz, Comparador dt, Logical h) 
            {
               // NodoAvl n1;
                if (raiz == null)
                {
                    raiz = new NodoAvl(dt);
                    h.setLogical(true);
                }
               
                else if (dt.menorNumero(raiz.valorNodo()))
                {
                    ramaDerecha(raiz, dt, h);               
                }
                else if (dt.mayorNumero(raiz.valorNodo()))
                {            
                    ramaIzquierda(raiz, dt, h);               
                }
                    // raiz 1 Guatemala loclla
                    //      derecho 1. zacapa lolo

                    //    1 zacapa papa
                else if (dt.igualque(raiz.valorNodo()))
                {
                    if (dt.departamentoMayor(raiz.valorNodo()))
                    {
                       raiz= ramaDerecha(raiz, dt, h);
                    }

                    else if (dt.departamentoMenor(raiz.valorNodo()))
                    {
                       raiz= ramaIzquierda(raiz, dt, h);
                    }

                    else if (dt.departamentoIgual(raiz.valorNodo()))
                    {

                        if (dt.nombreAlfabeticoDer(raiz.valorNodo()))
                           raiz= ramaDerecha(raiz, dt, h);

                        else if (dt.nombreAlfabeticoIzq(raiz.valorNodo()))
                            raiz= ramaIzquierda(raiz, dt, h);
                    }
                }

                else
                    throw new Exception("No puede haber claves repetidas " );
                return raiz;
            }


       private NodoAvl ramaIzquierda(NodoAvl raiz, Comparador dt, Logical h)
        {
                   NodoAvl n1;
                   NodoAvl iz;
                    iz = insertarAvl((NodoAvl) raiz.subarbolIzdo(), dt, h);
                    raiz.ramaIzdo(iz);
                    // regreso por los nodos del camino de búsqueda
                    if (h.booleanValue())
                    {
                        // decrementa el fe por aumentar la altura de rama izquierda
                        switch (raiz.fe)
                        {
                        case 1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                        case 0:
                            raiz.fe = -1;
                            break;
                        case -1: // aplicar rotación a la izquierda
                            n1 = (NodoAvl)raiz.subarbolIzdo();
                            if (n1.fe == -1)
                                raiz = rotacionII(raiz, n1);
                            else
                                raiz = rotacionID(raiz, n1);
                                h.setLogical(false);
                            break;
           
                
                }
                    } return raiz;
        }
        private NodoAvl ramaDerecha(NodoAvl raiz, Comparador dt, Logical h)
       {
           NodoAvl n1;
           NodoAvl dr;
           dr = insertarAvl((NodoAvl)raiz.subarbolDcho(), dt, h);
           raiz.ramaDcho(dr);
           // regreso por los nodos del camino de búsqueda
           if (h.booleanValue())
           {
               // incrementa el fe por aumentar la altura de rama izquierda
               switch (raiz.fe)
               {
                   case 1: // aplicar rotación a la derecha
                       n1 = (NodoAvl)raiz.subarbolDcho();
                       if (n1.fe == +1)
                           raiz = rotacionDD(raiz, n1);
                       else
                           raiz = rotacionDI(raiz, n1);
                       h.setLogical(false);
                       break;
                   case 0:
                       raiz.fe = +1;
                       break;
                   case -1:
                       raiz.fe = 0;
                       h.setLogical(false);
                       break;
               }

           } return raiz;
       }

        public Nodo buscar(Object buscado)
        {
            Comparador dato;
            dato = (Comparador)buscado;
            if (raiz == null)
                return null;
            else
                return buscar(raizArbol(), dato);
        }

        protected Nodo buscar(Nodo raizSub, Comparador buscado)
        {
            if (raizSub == null)
                return null;
            else if (buscado.nombreIgualDep(raizSub.valorNodo()))
                return raizSub;
            else if (buscado.nombreDiferentDep(raizSub.valorNodo()))
                return buscar(raizSub.subarbolIzdo(), buscado);
            else
                return buscar(raizSub.subarbolDcho(), buscado);
        }

          
        
        /////////////////////////////////
        /// <summary>
        /// Comprueba el estatus del árbol
        /// </summary>
        /// <returns></returns>
         bool esVacio()
        {
            return raiz == null;
        }

        public static NodoAvl nuevoArbol(NodoAvl ramaIzqda, Object dato, NodoAvl ramaDrcha)
        {
            return new NodoAvl( dato,ramaIzqda, ramaDrcha);
        }


        //binario en preorden
        public static string preorden(Nodo r)
        {
            if (r != null)
            {
                return r.visitar() + preorden (r.subarbolIzdo()) + preorden (r.subarbolDcho());
            }
            return "";
        } 
        
        // Recorrido de un árbol binario en inorden
        public static string inorden(Nodo r)
        {
            if (r != null)
            {
                return inorden (r.subarbolIzdo()) + r.visitar() + inorden (r.subarbolDcho());
            }
            return "";
        } 
        
        // Recorrido de un árbol binario en postorden
        public static string postorden(Nodo r)
        {
            if (r != null)
            {
                return postorden (r.subarbolIzdo()) + postorden (r.subarbolDcho()) + r.visitar();
            }
            return "";
        }

        //Devuelve el número de nodos que tiene el árbol
        public static int numNodos(Nodo raiz)
        {
            if (raiz == null)
                return 0;
            else
                return 1 + numNodos(raiz.subarbolIzdo()) +
                numNodos(raiz.subarbolDcho());
        }
    }

    }

