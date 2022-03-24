namespace TaxService.Application.Exceptions;

public class InvalidFormatException : Exception
{
    public InvalidFormatException() : base() { }

    public override string Message => "Query string format is not valid";
}
