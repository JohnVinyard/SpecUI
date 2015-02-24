using System;
using System.Collections.Generic;
using System.Linq;
using SpecUI.Attributes;
using SpecUI.Extensions;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("The shipment's title is one of a set of values")]
    public class TitleIsOneOf : BaseShipmentSpec
    {
        [Description("One of a set of title the shipment should match")]
        public IEnumerable<string> Titles { get; set; }

        public override bool IsSatisfied(Shipment shipment) {
            return Titles.Contains(shipment.Title);
        }

        public override IEnumerable<IValidationError> IsValid()
        {
            if (Titles.IsNullOrEmpty()) {
                yield return new ValidationError(
                    message: "You must supply one or more titles");
                yield break;
            }

            foreach (var title in Titles.Where(String.IsNullOrWhiteSpace))
            {
                yield return new ValidationError(
                    message: "All titles must have a value");
            }
        }
    }
}