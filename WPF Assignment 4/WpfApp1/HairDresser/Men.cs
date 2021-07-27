using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDresser
{
    class Men : Customer
    {
        public Men()
        {
        }

        public Men(string name, int age, int height, string creditCard) : base(name, age, height, creditCard)
        {
        }

        public new void HairWash()
        {
            Console.WriteLine("Hair Wash added for Gentlemen");
        }

        public override void HairTrim()
        {
            Console.WriteLine("Hair Trim is added for Gentlemen");
        }

        public override void HairDye()
        {
            Console.WriteLine("Hair Dye is added for Gentlemen");
        }

        public override void AdditionalServices()
        {
            Console.WriteLine("For gentlemen salon can offer trimming beard and moustaches");
        }
    }
}
