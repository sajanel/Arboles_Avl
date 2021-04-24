using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolesExamen.Estucturas
{
  public interface Comparador
    {
        bool igualque(object q);
        bool mayorNumero(object q);
        bool menorNumero(object q);
        bool departamentoMayor(object q);
        bool departamentoMenor(object q);
        bool departamentoIgual(object q);
        bool nombreAlfabeticoIzq(object q);
        bool nombreAlfabeticoDer(object q);
        bool nombreIgualDep(object q);
        bool nombreDiferentDep(object q);
    }
}
