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
        public abstract string UserErrorMessage();
    }
    internal class NumericInputError : UserError
    {
        private const string name = "NumericInputError";
        public NumericInputError()
        {

        }
        public override string ToString()
        {
            return name;
        }
        public override string UserErrorMessage()
        {
            string message = "You tried to use a numeric input in a text only field. This fired an error!";

            return message;
        }      
        }
    internal class TextInputError : UserError
    {
        private const string name = "TextInputError";      
        public TextInputError()
        {

        }
        public override string ToString()
        {
            return name;
        }
        public override string UserErrorMessage()
        {
            string message = "You tried to use a text input in a numeric only field. This fired an error!";

            return message;
        }
    }
}
