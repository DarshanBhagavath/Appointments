using System;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class Appointment: IComparable<Appointment>
    {
        private string service;
        private string time;
        private string name;
        private string category;
        private int age;
        private int height;
        private string credit;

        public string Time { get => time; set => time = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public int Age { get => age; set => age = value; }
        public int Height { get => height; set => height = value; }
        public string Credit { get => credit; set => credit = value; }
        public string Service { get => service; set => service = value; }

        public Appointment(string service, string time, string name, string category, int age, int height, string credit ) {
          
            this.Service = service;
            this.time = time;
            this.name = name;
            this.category = category;
            this.age = age;
            this.height = height;
            this.credit = credit;
        }

        public int CompareTo(Appointment other)
        {
            return age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return string.Format("hello {1}, Appointment for {6} Time: {0}, Category: {2}, Age is {3}, height {4}cm, Credit Card No: {5}", time, name, category, age, height, credit, service);
        }
    }


              
}
