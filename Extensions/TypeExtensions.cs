using System;
using System.Collections.Generic;

namespace SpecUI.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsCollection(this Type t) {
            if (t.IsArray) { return true; }
            return t.IsGenericType
                   && (t.GetGenericTypeDefinition() == typeof(IList<>)
                    || t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }
    }
}