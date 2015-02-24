using System;
using System.Collections.Generic;
using System.Linq;
using SpecUI.Attributes;
using SpecUI.Extensions;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("A totally contrived example to mix arrays and non-arrays")]
    public class TotallyContrived : BaseShipmentSpec
    {
        public IEnumerable<string> Values { get; set; }
        public string OtherValue { get; set; }

        public override bool IsSatisfied(Shipment shipment)
        {
            return true;
        }

        public override IEnumerable<IValidationError> IsValid()
        {
            if (Values.IsNullOrEmpty())
            {
                yield return new ValidationError(
                    "Values must have at least one value");
            }

            if (Values.Any(String.IsNullOrEmpty))
            {
                yield return new ValidationError(
                    "All Values must not be null or empty");
            }

            if (String.IsNullOrEmpty(OtherValue))
            {
                yield return new ValidationError(
                    "OtherValue must not be null or empty",
                    criterionName: () => OtherValue);
            }
        }
    }
}
