using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SpecUI.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetImplementations<T>(
            this Assembly assembly) where T : class {

            return assembly.GetTypes()
                .Where(x =>
                        x != typeof(T)
                        && typeof(T).IsAssignableFrom(x)
                        && !x.IsAbstract);
            }
    }
}