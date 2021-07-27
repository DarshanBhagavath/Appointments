using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDresser
{
    class Women : Customer
    {
        public Women()
        {
        }

        public Women(string name, int age, int height, string creditCard) : base(name, age, height, creditCard)
        {
        }

        public new void HairWash()
        {
            Console.WriteLine("Hair Wash added for Ladies");
        }

        public override void HairTrim()
        {
            Console.WriteLine("Hair Trim is added for Ladies");
        }

        public override void HairDye()
        {
            Console.WriteLine("Hair Dye is added for Ladies");
        }

        public override void AdditionalServices()
        {
            Console.WriteLine("For ladies salon can offer additional hair styling for occasions");
        }
    }
}
