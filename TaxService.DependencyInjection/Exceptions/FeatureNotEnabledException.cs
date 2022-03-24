namespace TaxService.Application.Exceptions;

public class FeatureNotEnabledException : Exception
{
    public FeatureNotEnabledException() : base() { }

    public override string Message => "Requested feature or version not enabled";
}
