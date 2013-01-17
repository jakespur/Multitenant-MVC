using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multitenant.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool FileNotFound(this string filePath)
        {
            return !System.IO.File.Exists(filePath);
        }
    }

    public static class ObjectExtensions
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }
    }
}
