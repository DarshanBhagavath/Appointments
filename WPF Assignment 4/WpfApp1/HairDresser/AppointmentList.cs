using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDresser
{
    class AppointmentList : IDisposable
    {
        private string time;
        private List<IAppointment> customerList = null;

        public string Time { get => time; set => time = value; }

        public AppointmentList()
        {
            customerList = new List<IAppointment>();
        }

        public void Add(IAppointment customer)
        {
            customerList.Add(customer);
        }

        public int Count()
        {
            return customerList.Count();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IAppointment this[int i]
        {
            get { return customerList[i]; }
        }

        public void Sort()
        {
            customerList.Sort();
        }
    }
}
