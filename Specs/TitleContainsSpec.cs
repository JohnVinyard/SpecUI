using System;
using System.Collections.Generic;
using SpecUI.Attributes;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("The shipment's title should contain a particular value")]
    public class TitleContainsSpec : BaseShipmentSpec
    {
        [Description("The value the shipment's title must contain")]
        public string SearchFor { get; set; }

        public override bool IsSatisfied(Shipment shipment) {
            return shipment.Title.Contains(SearchFor);
        }

        public override IEnumerable<IValidationError> IsValid() {
            if (String.IsNullOrWhiteSpace(SearchFor)) {
                yield return new ValidationError(
                    message: "You must provide a value",
                    criterionName: () => SearchFor);
            }
        }
    }
}