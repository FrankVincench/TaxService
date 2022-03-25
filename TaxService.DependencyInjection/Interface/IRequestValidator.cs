using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxService.Domain;

namespace TaxService.Application.Interface;

public interface IRequestValidator<T>
{
    void ValidateModel(T model);
}
