using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using SpecUI.Models;
using SpecUI.Specs;
using SpecUI.Attributes;

namespace SpecUI.Extensions
{
    public static class ShipmentSpecExtensions
    {
        public static SpecModel ToSpecModel(this IShipmentSpec spec) {
            var t = spec.GetType();
            return new SpecModel {
                Name = t.Name,
                Description = t
                    .GetCustomAttribute<DescriptionAttribute>()
                    .IfNotNull(x => x.Description),
                Criteria = t
                    .GetProperties()
                    .Select(p => Transform(p, spec))
            };
        }

        public static IEnumerable<SpecModel> GetMetaData() {
            var types =
                typeof(ShipmentSpecExtensions)
                .Assembly
                .GetImplementations<IShipmentSpec>()
                .ToList();

            return types
                .Select(t => new SpecModel {
                    Name = t.Name,
                    Description = t
                        .GetCustomAttribute<DescriptionAttribute>()
                        .IfNotNull(x => x.Description),
                    Criteria = t
                        .GetProperties()
                        .Select(p => Transform(p))
                });
        }

        private static CriterionModel Transform(
            PropertyInfo property, object instance = null) {

            var t = property.PropertyType;
            return new CriterionModel {
                Name = property.Name,
                Type = GetJsType(t),
                Description = property
                    .GetCustomAttribute<DescriptionAttribute>()
                    .IfNotNull(x => x.Description),
                Value = instance != null ?
                    property.GetGetMethod().Invoke(instance, new object[] { })
                    : null,
                Options = GetOptions(t),
                IsArray = t.IsCollection()
            };
        }

        private static JavascriptType GetJsType(Type t) {
            if (t == typeof(string) || t.IsEnum) {
                return JavascriptType.String;
            }

            if (t == typeof(bool)) {
                return JavascriptType.Boolean;
            }

            if (t == typeof(int) || t == typeof(float) || t == typeof(decimal)) {
                return JavascriptType.Number;
            }

            if (t.IsCollection()) {
                return GetJsType(t.GetGenericArguments()[0]);
            }

            throw new ArgumentOutOfRangeException("t");
        }

        private static IEnumerable<object> GetOptions(Type t) {
            if (t.IsEnum) {
                return Enum.GetValues(t).Cast<object>();
            }

            if (t.IsCollection()) {
                return GetOptions(t.GetGenericArguments()[0]);
            }
            return Enumerable.Empty<object>();
        }
    }
}
