namespace TaxService.Application.Exceptions;

public class InvalidStateException : Exception
{
    public InvalidStateException() : base(){}

    public override string Message => "State format is not valid";
}
