using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxService.Application.Exceptions;

public class TaxJarResponseException : Exception
{
    private static readonly string DEFAULT_MESSAGE = "An error ocurred while communicating with the Tax JAR API";
    public TaxJarResponseException()
        :base(DEFAULT_MESSAGE){}

    public TaxJarResponseException(string exceptionMessage)
        : base(exceptionMessage) { }
}
