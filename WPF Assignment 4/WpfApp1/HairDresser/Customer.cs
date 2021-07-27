using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDresser
{
    abstract class Customer : IAppointment
    {
        private string name;
        private int age;
        private int height;
        private string creditCard;
        private CustomerDelegate custDel = null;

        public Customer()
        {
            SetUpDelegate();
        }

        public Customer(string name, int age, int height, string creditCard)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.age = age;
            this.creditCard = creditCard;
            SetUpDelegate();
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int Height { get => height; set => height = value; }
        public string CreditCard { get => creditCard; set => creditCard = value; }
        public CustomerDelegate CustDel { get => custDel; set => custDel = value; }
        public string ViewCreditCard { get => ConcealedCreditCard(); }             

        public void HairWash()
        {
            Console.WriteLine("Hair Wash Added");
        }

        public virtual void HairTrim()
        {
            Console.WriteLine("Hair Trim Added");
        }

        public virtual void HairDye()
        {
            Console.WriteLine("Hair Dye Added");
        }

        public abstract void AdditionalServices();

        public int CompareTo(IAppointment other)
        {
            return age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return string.Format("hello {0}, age is {1}, height {2}cm , Credit card no: {3} ", name, age, height, ViewCreditCard);
        }

        private void SetUpDelegate()
        {
            custDel += HairWash;
            custDel += HairTrim;
            custDel += HairDye;
            custDel += AdditionalServices;
        }

        private string ConcealedCreditCard()
        {
            char[] credArray = CreditCard.ToCharArray();
            for (int i = 5; i <= 12; i++)
            {
                credArray[i] = 'X';
            }
            string credNo = new string(credArray);
            credNo = credNo.Remove(0, 0);
            credArray = credNo.ToCharArray();
            return new string(credArray);
        }
    }
}
