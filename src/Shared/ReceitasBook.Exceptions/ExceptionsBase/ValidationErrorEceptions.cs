using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Exceptions.ExceptionsBase
{
    public class ValidationErrorEceptions: ReceitasBookException
    {
        public List<string> ErrorsList;

        public ValidationErrorEceptions(List<string> Errors) : base(string.Empty)
        {
            ErrorsList = Errors;
        }
    }
}
