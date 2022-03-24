namespace TaxService.Application.Exceptions;

public class RequestLimitException : Exception
{
    public RequestLimitException() : base() { }

    public override string Message => "Api request limit met";
}
