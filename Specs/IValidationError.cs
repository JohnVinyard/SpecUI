namespace SpecUI.Specs
{
    public interface IValidationError
    {
        string Message { get; }
        string CriterionName { get; }
    }
}