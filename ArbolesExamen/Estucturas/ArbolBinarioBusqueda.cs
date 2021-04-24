using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolesExamen.Estucturas
{
    class ArbolBinarioBusqueda : ArbolBinario
    {
        public ArbolBinarioBusqueda(): base()
        {
        }

        public ArbolBinarioBusqueda(Nodo nodo): base(nodo)
        {
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
            else if (buscado.departamentoIgual(raizSub.valorNodo()))
                return raizSub;
            else if (buscado.departamentoMenor(raizSub.valorNodo()))
                return buscar(raizSub.subarbolIzdo(), buscado);
            else
                return buscar(raizSub.subarbolDcho(), buscado);
        }
    }   
 }

