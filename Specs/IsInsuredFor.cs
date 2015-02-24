using System.Collections.Generic;
using SpecUI.Attributes;
using SpecUI.Models;

namespace SpecUI.Specs
{
    [Description("The shipment is insured for a minimum amount")]
    public class IsInsuredFor : BaseShipmentSpec
    {
        [Description("The minimum insurance amount")]
        public decimal MinimumAmount { get; set; }

        public override bool IsSatisfied(Shipment shipment)
        {
            return shipment.InsuranceAmount >= MinimumAmount;
        }

        public override IEnumerable<IValidationError> IsValid()
        {
            if (MinimumAmount <= 0)
            {
                yield return new ValidationError(
                    message: "amount must be greater than zero",
                    criterionName:() => MinimumAmount);
            }
        }
    }
}
