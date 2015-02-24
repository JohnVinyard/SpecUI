using System.Collections.Generic;
using SpecUI.Models;

namespace SpecUI.Specs
{
    public interface IShipmentSpec : ISpecification<Shipment>
    {
        IEnumerable<IValidationError> IsValid();
    }
}