using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDresser
{
    public delegate void CustomerDelegate();
    interface IAppointment : IComparable<IAppointment>
    {
        string Name { get; set; }
        int Age { get; set; }
        int Height { get; set; }        
        string CreditCard { get; set; }

        CustomerDelegate CustDel { get; set; }
        void HairWash();
        void HairTrim();
        void HairDye();
        void AdditionalServices();        
    }
}
