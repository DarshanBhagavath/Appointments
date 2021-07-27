using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDresser
{
    class Children : Customer
    {
        public Children()
        {
        }

        public Children(string name, int age, int height, string creditCard) : base(name, age, height, creditCard)
        {
        }

        public new void HairWash()
        {
            Console.WriteLine("Hair Wash added for Childrens");
        }

        public override void HairTrim()
        {
            Console.WriteLine("Hair Trim is added for Childrens");
        }

        public override void HairDye()
        {
            Console.WriteLine("Hair Dye is added for Childrens");
        }

        public override void AdditionalServices()
        {
            Console.WriteLine("For children salon can offer sensitive trimmers and seats adjustable for height");
        }
    }
}
