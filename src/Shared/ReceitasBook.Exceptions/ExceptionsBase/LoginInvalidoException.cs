using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Exceptions.ExceptionsBase;

public class LoginInvalidoException: ReceitasBookException
{
    public LoginInvalidoException() : base(ResourceMessageError.LOGIN_INVALIDO)
    {

    }
}
