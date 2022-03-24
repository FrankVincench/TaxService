using TaxService.Application.Exceptions;
using TaxService.Application.Interface;

namespace TaxService.Application.Behavior;

public class ExceptionBehavior : IException
{
    public void Handle(int responseCode)
    {
        switch (responseCode)
        {
            case 101:
                throw new InvalidKeyException();
            case 102:
                throw new InvalidStateException();
            case 103:
                throw new InvalidCityException();
            case 104:
                throw new InvalidPostalCodeException();
            case 105:
                throw new InvalidFormatException();
            case 106:
                throw new ApiErrorException();
            case 107:
                throw new FeatureNotEnabledException();
            case 108:
                throw new RequestLimitException();
            case 109:
                throw new IncompleteAddressException();
            default:
                break;
        }
    }
}


//100	SUCCESS Successful API Requet
//101	INVALID_KEY Key format is not valid
//102	INVALID_STATE State format is not valid
//103	INVALID_CITY City format is not valid
//104	INVALID_POSTAL_CODE Postal code format is not valid
//105	INVALID_FORMAT Query string format is not valid
//106	API_ERROR Api error
//107	FEATURE_NOT_ENABLED Requested feature or version not enabled
//108	REQUEST_LIMIT_MET Api request limit met
//109	ADDRESS_INCOMPLETE Missing address parameters