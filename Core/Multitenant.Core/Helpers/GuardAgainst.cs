using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multitenant.Core.Helpers
{
    public static class GuardAgainst
    {
        public static void Null(object param)
        {
            if (param == null) throw new ArgumentNullException("Argument cannot be null");
        }
    }
}
