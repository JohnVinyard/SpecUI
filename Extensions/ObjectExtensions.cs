using System;

namespace SpecUI.Extensions
{
    public static class ObjectExtensions
    {
        public static TProperty IfNotNull<TObject,TProperty>(
            this TObject obj, Func<TObject,TProperty> f) where TObject : class {
            return obj == null ? default(TProperty) : f(obj);
            }
    }
}