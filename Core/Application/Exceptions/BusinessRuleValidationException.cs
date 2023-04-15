using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(string message) : base(message)
        {
        }
        public BusinessRuleValidationException() : this("Logic is not valid")
        {
        }
        public BusinessRuleValidationException(Exception ex) : this(ex.Message)
        {
        }
    }
}
