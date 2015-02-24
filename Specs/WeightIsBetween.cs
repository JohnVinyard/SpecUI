using System.Collections.Generic;
using SpecUI.Attributes;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("The shipment weight must be within a specified range")]
    public class WeightIsBetween : BaseShipmentSpec
    {
        [Description("The minimum weight of the shipment, in pounds")]
        public int MinWeightPounds { get; set; }

        [Description("The maximum weight of the shipment, in pounds")]
        public int MaxWeightPounds { get; set; }

        public override bool IsSatisfied(Shipment shipment) {
            return
                shipment.WeightPounds > MinWeightPounds
                && shipment.WeightPounds < MaxWeightPounds;
        }

        public override IEnumerable<IValidationError> IsValid() {
            if (MinWeightPounds < 1) {
                yield return new ValidationError(
                    message: "min weight must be greater than zero",
                    criterionName: () => MinWeightPounds);
            }

            if (MaxWeightPounds <= MinWeightPounds) {
                yield return new ValidationError(
                    message: "max weight must be greater than min weight");
            }
        }
    }
}