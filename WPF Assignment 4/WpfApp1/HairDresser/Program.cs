using System; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace HairDresser
{
    class Program
    {
        string CreditCard = string.Empty;
        enum AppointmentSlots
        {
            AM8 = 0,
            AM9 = 1,
            AM10 = 2,
            AM11 = 3,
            PM1 = 4,
            PM2 = 5,
            PM3 = 6,
            PM4 = 7,
            PM5 = 8
        }

        enum Groups
        {
            men,
            women,
            children
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Go();
            Console.ReadKey();
        }

        public void Go()
        {
            string userchoice = string.Empty;
            // userchoice pressing Y for continuing the porgram or pressing N for termination
            List<string> booked = new List<string>(); // To handle already booked slots

            var slotTypes = Enum.GetNames(typeof(AppointmentSlots));
            var slotValues = Enum.GetValues(typeof(AppointmentSlots));

            Hashtable containTime = new Hashtable();
            AppointmentList[] appointments = new AppointmentList[slotTypes.Length]; // this array will hold all the appointments 

            using (AppointmentList al = new AppointmentList())
            {
                for (int i = 0; i < slotTypes.Length; i++)
                {
                    string slotType = (string)slotTypes[i];
                    int slotPlace = (int)slotValues.GetValue(i);
                    string ampm = slotType.Substring(0, 2);
                    string formatTime = slotType.Substring(slotType.LastIndexOf('M') + 1) + ":00 ";
                    formatTime += ampm;
                    containTime.Add(slotPlace, formatTime);

                    //Array of appointments initialized
                    appointments[i] = new AppointmentList();
                    appointments[i].Time = formatTime;  // tthe first part will contain the time
                }
                bool appointmentRequired = false;
                do
                {
                    do
                    {
                        Console.Write("Do you need an appointment [Y/N]? ");
                        userchoice = Console.ReadLine();
                    } while ((userchoice.ToUpper() != "Y") && (userchoice.ToUpper() != "N"));
                    userchoice = userchoice.ToUpper();

                    if (userchoice == "N")
                    {
                        appointmentRequired = false;
                        continue;
                    }
                    string slotChoice = string.Empty;
                    int slot = 0;
                    foreach (int val in slotValues)
                    {
                        if (containTime.ContainsKey(val))
                        {
                            Console.WriteLine("{0}. {1}", (int)val + 1, containTime[val]);
                        }
                    }
                    do
                    {
                        Console.Write("Please choose available slot: ");
                        slotChoice = Console.ReadLine();
                    } while ((!int.TryParse(slotChoice, out slot)) || (slot < 0) || (booked.Contains(slotChoice)));

                    if (slot == 0)
                    {
                        appointmentRequired = false;
                        continue;
                    }
                    else if ((slot > 0))
                    {
                        var category = Enum.GetValues(typeof(Groups));      // extracting category from the groups enum
                        int idForCategory = 1;
                        foreach (var val in category)
                        {
                            Console.WriteLine("{0}: {1}", idForCategory, val);
                            idForCategory++;
                        }

                        string categoryChoice = String.Empty;
                        int choice = 0;

                        //choosing the category for the customers 
                        do
                        {
                            Console.Write("Choose your category: ");
                            categoryChoice = Console.ReadLine();
                        } while ((!int.TryParse(categoryChoice, out choice) || ((choice < 0) || (choice > category.Length))));
                        string name = string.Empty;
                        int age = 0;
                        int height = 0;
                        string credit = string.Empty;
                        //after getting choice of category collecting all the required information 
                        if (choice > 0)
                        {
                            do
                            {
                                Console.Write("Enter your name :");
                                name = Console.ReadLine();
                            } while (name == string.Empty);


                            string yourAge = string.Empty;
                            do
                            {
                                Console.Write("Enter your age [1-150] : ");
                                yourAge = Console.ReadLine();
                            } while ((!int.TryParse(yourAge, out age) || (age < 0) || (age > 150)));      // age minimum 1 and maximum 149
                            string yourHeight = string.Empty;
                            do
                            {
                                Console.Write("Enter your height in cm [0-300] :");
                                yourHeight = Console.ReadLine();
                            } while ((!int.TryParse(yourHeight, out height) || (height < 0) || (height > 300)));  // height minimum 1 maximm 299

                            do
                            {
                                Console.Write("Enter Credit card details as per the format [#4511 1111 1111 1111]: ");
                                CreditCard = Console.ReadLine();
                            } while ((CreditCard == string.Empty) || (CreditCard.Trim().Length < 20) || (!CheckCreditCard()));

                            if (CreditCard != string.Empty)
                            {
                                credit = CreditCard;
                            }

                            // overriding it to the desired category according to the user                        
                            switch (choice)
                            {
                                case 1:
                                    Men mn = new Men(name, age, height, credit);
                                    al.Add(mn);
                                    break;

                                case 2:
                                    Women wm = new Women(name, age, height, credit);
                                    al.Add(wm);
                                    break;

                                case 3:
                                    Children ch = new Children(name, age, height, credit);
                                    al.Add(ch);
                                    break;
                                default:
                                    Console.WriteLine("you should not be here");
                                    break;
                            }
                        }
                        appointmentRequired = true;
                        containTime.Remove(slot - 1);
                        booked.Add(slotChoice);  // Adding the already booked slot time
                    }
                } while ((appointmentRequired) && (containTime.Keys.Count > 0));

                al.Sort();

                for (int i = 0; i < al.Count(); i++)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.WriteLine("Appointment #{0}", i + 1);
                    Console.WriteLine(al[i]);
                    al[i].CustDel();
                }
            }
        }

        public bool CheckCreditCard()
        {
            bool result = false;
            CreditCard = Regex.Replace(CreditCard, @"\s", "");
            if (CreditCard != null && CreditCard != string.Empty)
            {
                char[] credArray = CreditCard.ToCharArray();
                if ((credArray[0]) == '#')
                {
                    for (int i = 1; i < credArray.Length; i++)
                    {
                        if (char.IsDigit(credArray[i]))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
