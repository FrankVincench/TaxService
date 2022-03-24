namespace TaxService.Application.Exceptions;

public class InvalidKeyException : Exception
{
    public InvalidKeyException() : base() { }

    public override string Message => "Key format is not valid";
}
