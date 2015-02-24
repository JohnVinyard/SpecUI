using System.Collections.Generic;
using SpecUI.Attributes;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("The shipment originates from a particular location type")]
    public class HasLocationType : BaseShipmentSpec
    {
        [Description("The location type the shipment must originate from")]
        public LocationType LocationType { get; set; }

        public override bool IsSatisfied(Shipment shipment) {
            return shipment.LocationType == LocationType;
        }

        public override IEnumerable<IValidationError> IsValid() {
            yield break;
        }
    }
}