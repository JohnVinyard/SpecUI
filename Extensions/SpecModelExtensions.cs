using System;
using System.Linq;
using SpecUI.Models;
using SpecUI.Specs;

namespace SpecUI.Extensions
{
    public static class SpecModelExtensions
    {
        public static IShipmentSpec ToSpec(this SpecModel model)
        {
            var t = typeof(SpecModelExtensions)
                .Assembly
                .GetImplementations<IShipmentSpec>()
                .First(x => x.Name == model.Name);

            var instance = Activator.CreateInstance(t);
            foreach (var c in model.Criteria)
            {
                var property = t.GetProperty(c.Name);
                var setter = property.GetSetMethod();
                setter.Invoke(instance, new[] { 
                    ConvertTo(c.Value,property.PropertyType)
                });
            }
            return instance as IShipmentSpec;
        }

        private static object ConvertTo(object value, Type t)
        {
            if (t.IsEnum)
            {
                return Enum.Parse(t, value.ToString());
            }
            if (t.IsCollection())
            {
                var v = value as Newtonsoft.Json.Linq.JArray;
                return v.ToObject(t);
            }
            try
            {
                return Convert.ChangeType(value, t);
            }
            catch (InvalidCastException)
            {
                // KLUDGE: This is a total hack.  It just happens to 
                // work for now
                return ConvertTo(0, t);
            }
            catch (FormatException)
            {
                // KLUDGE: This is a total hack.  It just happens to 
                // work for now
                return ConvertTo(0, t);
            }

        }
    }
}