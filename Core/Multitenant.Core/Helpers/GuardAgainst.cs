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

    public static class Assert
    {
        public static bool IsNotNull(object entity)
        {
            return entity != null;
        }

        public static bool FileIsValid(string path)
        {
            return System.IO.File.Exists(path);
        }
    }
}
