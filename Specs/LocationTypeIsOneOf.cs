using System.Collections.Generic;
using System.Linq;
using SpecUI.Extensions;
using SpecUI.Models;
using SpecUI.Attributes;

namespace SpecUI.Specs
{
    [Description("The shipment originates from one of a set of allowed location types")]
    public class LocationTypeIsOneOf : BaseShipmentSpec
    {
        [Description("The location type the shipment must originate from")]
        public IEnumerable<LocationType> LocationTypes { get; set; }

        public override bool IsSatisfied(Shipment shipment) {
            return LocationTypes.Contains(shipment.LocationType);
        }

        public override IEnumerable<IValidationError> IsValid() {
            if (LocationTypes.IsNullOrEmpty()) {
                yield return new ValidationError(
                    message: "you must specify at least one location type");
            }
        }
    }

}
