using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Ovn3
{
    internal abstract class UserError
    {
        public abstract string UEMessage();

    }
    internal class NumericInputError : UserError
    {
        public NumericInputError()
        {

        }
        public override string UEMessage()
        {
            string message = "You tried to use a numeric input in a text only field. This fired an error!";

            return message;
        }

        
        }
    internal class TextInputError : UserError
    {
        public TextInputError()
        {

        }
        public override string UEMessage()
        {
            string message = "You tried to use a text input in a numeric only field. This fired an error!";

            return message;
        }
    }
}
