using System;
using System.Runtime.CompilerServices;

namespace ExtensionMethodClass
{
    public static class ExtensionClass
    {
        public static bool intIsGreaterThan(this int objectSelf, int value)
        {
            return objectSelf > value;
        }

        public static bool intIsGreaterThan(this string objectSelf, int value)
        {
            return Convert.ToInt32(objectSelf) > value;
        }
    }
}
