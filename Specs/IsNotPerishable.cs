using System.Collections.Generic;
using SpecUI.Attributes;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("The shipment's contents are not perishable, e.g., food products")]
    public class IsNotPerishable : BaseShipmentSpec
    {
        public override bool IsSatisfied(Shipment shipment) {
            return !shipment.IsPerishable;
        }

        public override IEnumerable<IValidationError> IsValid() {
            yield break;
        }
    }
}