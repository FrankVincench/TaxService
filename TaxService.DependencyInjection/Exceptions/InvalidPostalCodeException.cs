namespace TaxService.Application.Exceptions;

public class InvalidPostalCodeException : Exception
{
    public InvalidPostalCodeException() : base() { }

    public override string Message => "PostalCode format is not valid";
}
