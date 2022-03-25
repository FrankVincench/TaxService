namespace TaxService.Application.Interface;

public interface IRequestValidator<T>
{
    void ValidateModel(T model);
}
