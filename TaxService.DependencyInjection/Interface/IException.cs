using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxService.Application.Interface;

public interface IException
{
    void Handle(int responseCode);
}
