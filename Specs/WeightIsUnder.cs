using System.Collections.Generic;
using SpecUI.Attributes;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("The shipment weights below a certain amount")]
    public class WeightIsUnder : BaseShipmentSpec
    {
        [Description("The shipment must weigh less than")]
        public int MaxWeightPounds { get; set; }

        public override bool IsSatisfied(Shipment shipment) {
            return shipment.WeightPounds <= MaxWeightPounds;
        }

        public override IEnumerable<IValidationError> IsValid() {
            if (MaxWeightPounds < 1) {
                yield return new ValidationError(
                    message: "weight must be greater than zero",
                    criterionName: () => MaxWeightPounds);
            }
        }
    }
}