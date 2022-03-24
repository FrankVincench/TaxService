namespace TaxService.Application.Exceptions;

public class InvalidCityException : Exception
{
    public InvalidCityException() : base(){ }

    public override string Message => "City format is not valid";
}
