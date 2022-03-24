namespace TaxService.Application.Exceptions;

public class ApiErrorException : Exception
{
    public ApiErrorException() : base() { }

    public override string Message => "An error occured on the API";
}
