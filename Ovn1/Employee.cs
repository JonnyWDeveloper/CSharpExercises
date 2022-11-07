namespace Restaurang
{
    internal class Employee
    {
        private string firstName = "";
        private string lastName = "";
        private string currency = "";   //SEK, USD, GBP, etc.
        private int amount;             // Monthly wage

        public Employee(string firstname, string lastname, string moneyCurrency, int sum)
        {
            firstName = firstname.Trim();
            lastName = lastname.Trim();
            currency = moneyCurrency.Trim();
            amount = sum;
        }
        public string FirstName   //Property
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName   //Property
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Currency   //Property
        {
            get
            {
                return currency;
            }
            set
            {
                currency = value;
            }
        }
        public int Amount   //Property
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
    }
}

