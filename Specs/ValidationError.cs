using System;
using System.Linq.Expressions;
using SpecUI.Extensions;

namespace SpecUI.Specs
{
    public class ValidationError : IValidationError
    {
        public string Message { get; private set; }
        public string CriterionName { get; private set; }

        public ValidationError(
            string message,
            Expression<Func<object>> criterionName = null)
        {
            Message = message;
            CriterionName = criterionName.GetName();
        }

        public ValidationError(string message)
        {
            Message = message;
        }
    }
}