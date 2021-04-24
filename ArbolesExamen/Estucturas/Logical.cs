using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolesExamen.Estucturas
{
    class Logical
    {
        Boolean v;
        public Logical(Boolean f)
        {
            v = f;
        }
        public void setLogical(Boolean f)
        {
            v = f;
        }
        public Boolean booleanValue()
        {
            return v;
        }

    }
}
