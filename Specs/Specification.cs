namespace SpecUI.Specs
{
    public interface ISpecification<in T>
    {
        bool IsSatisfied(T subject);
    }
}
