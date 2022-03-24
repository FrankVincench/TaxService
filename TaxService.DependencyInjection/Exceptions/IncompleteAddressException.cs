namespace TaxService.Application.Exceptions;

public class IncompleteAddressException : Exception
{
    public IncompleteAddressException() : base() { }

    public override string Message => "Missing address parameters";
}
