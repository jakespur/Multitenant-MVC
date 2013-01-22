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
}
