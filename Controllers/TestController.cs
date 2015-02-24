using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net.Http;
using SpecUI.Data;
using SpecUI.Extensions;
using SpecUI.Models;
using SpecUI.Specs;

namespace SpecUI
{
    /*
     * TODO
     * 
     * Better UI
     * JS refactoring
     * C# refactoring
     * 
     * DONE Null values for value types
     * DONE Try mixing an array and non array value
     * DONE Descriptions don't come back after save()
     * DONE Add value by default when creating an array
     * DONE Remove values from array
     * DONE Spec descriptions
     * DONE Criterion descriptions
     * Validation
     *  - DONE must work for individual properties
     *  - DEFER must work for arrays
    */
    public class SpecsController : ApiController
    {
        public OutputModel Get([FromUri] string id)
        {
            IEnumerable<SpecModel> specs;
            try
            {
                specs = KeyValueStore.Instance
                    .Get<IList<IShipmentSpec>>(id)
                    .Select(x => x.ToSpecModel())
                    .ToList();
            }
            catch (KeyNotFoundException)
            {
                specs = new List<SpecModel>();
            }

            return new OutputModel
            {
                Specs = specs,
                Metadata = ShipmentSpecExtensions.GetMetaData()
            };
        }

        [ResponseType(typeof(OutputModel))]
        public HttpResponseMessage Put(
            [FromUri] string id,
            [FromBody] InputModel model)
        {

            var specModels = model.Specs.ToList();
            var specs = specModels.Select(x => x.ToSpec()).ToList();


            var hasErrors = false;
            for (var i = 0; i < specModels.Count; i++)
            {
                var errors = specs[i].IsValid().ToList();
                var specModel = specModels[i];
                foreach (var error in errors)
                {
                    hasErrors = true;
                    if (error.CriterionName == null)
                    {
                        specModel.ErrorMessage = error.Message;
                        continue;
                    }
                    var criterion = specModel.Criteria.First(
                        x => x.Name == error.CriterionName);
                    criterion.ErrorMessage = error.Message;
                }
            }

            if (!hasErrors)
            {
                KeyValueStore.Instance.Set(
                    id,
                    model.Specs.Select(x => x.ToSpec()).ToList());
            }

            return Request.CreateResponse(hasErrors ?
                HttpStatusCode.BadRequest : HttpStatusCode.Created,
                new OutputModel
                {
                    Specs = specModels,
                    Metadata = ShipmentSpecExtensions.GetMetaData()
                });
        }

    }


}
