using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;
using HairDresser;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        private List<Appointment> al = new List<Appointment>();
        public MainWindow()
        {
            InitializeComponent();
            StackMen.Visibility = Visibility.Hidden;
            StackWomen.Visibility = Visibility.Hidden;
            StackChildren.Visibility = Visibility.Hidden;

        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            int age = 0;
            int height = 0;

            if (txtName.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
                txtName.Foreground = Brushes.Red;
            }
            else if ((!int.TryParse(txtAge.Text, out age) || (age < 0) || (age > 150)))
            {
                MessageBox.Show("Please enter the valid Age");
                txtAge.Foreground = Brushes.Red;
            }
            else if ((!int.TryParse(txtHeight.Text, out height) || (height < 0) || (height > 300)))
            {
                MessageBox.Show("Please enter the valid Height");
                txtHeight.Foreground = Brushes.Red;
            }
            else if ((txtCreditCard.Text == string.Empty) || (txtCreditCard.Text.Trim().Length < 20) || (!CheckCreditCard()))
            {
                MessageBox.Show("Please enter the valid Credit Card No. with correct format");
                txtCreditCard.Foreground = Brushes.Red;
            }
            
            else
            {
                txtName.Foreground = Brushes.Black;
                txtAge.Foreground = Brushes.Black;
                txtHeight.Foreground = Brushes.Black;
                txtCreditCard.Foreground = Brushes.Black;


                string service = SelectService();
                Writeinfile(service, CmbTime.Text, txtName.Text, CmbCategory.Text, age, height, txtCreditCard.Text);
                ReadInFile("file.txt");
                ClearItems();
                Showbttn.IsEnabled = true;
                MessageBox.Show("Submission Succesfull.! Please click on Show Appointment to check the details!");


            }
        }

        public bool CheckCreditCard()
        {
            string CreditCard = string.Empty;

            bool result = false;
            CreditCard = txtCreditCard.Text;
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
        private string SelectService()
        {
            string result = string.Empty;

            if (chkHairstyling.IsChecked == true)
            {
                result += chkHairstyling.Content.ToString() + ",";
            }
            if (chkBeard.IsChecked == true) 
            {
                result += chkBeard.Content.ToString() + ",";
            }
            if (chkHairDye.IsChecked == true)
            {
                result += chkHairDye.Content.ToString() + ",";
            }
            if (chkHairTrim.IsChecked == true)
            {
                result += chkHairTrim.Content.ToString() + ",";
            }
            if (chkHairWash.IsChecked == true)
            {
                result += chkHairWash.Content.ToString() + ",";
            }
            if (chkMoustache.IsChecked == true)
            {
                result += chkMoustache.Content.ToString() + ",";
            }
            if (chkSenTrimming.IsChecked == true)
            {
                result += chkSenTrimming.Content.ToString() + ",";
            }

            return result;
        }

        public void ClearItems()
        {
            //To delete the selected appointmnet time
            CmbTime.Items.Remove(CmbTime.SelectedItem);
            CmbTime.SelectedIndex = -1;
            CmbCategory.SelectedIndex = -1;
            txtName.Text = "";
            txtAge.Text = "";
            txtHeight.Text = "";
            txtCreditCard.Text = "";
            txtblck.Text = "";
            chkBeard.IsChecked = false;
            chkHairDye.IsChecked = false;
            chkHairstyling.IsChecked = false;
            chkHairTrim.IsChecked = false;
            chkHairWash.IsChecked = false;
            chkMoustache.IsChecked = false;
            chkSenTrimming.IsChecked = false;
        }

        private void rdYes_Checked(object sender, RoutedEventArgs e)
        {
            if (rdYes.IsChecked == true)
            {
                btnClick.IsEnabled = true;
            }
        }

        private void rdNo_Checked(object sender, RoutedEventArgs e)
        {
            if (rdNo.IsChecked == true)
            {
                btnClick.IsEnabled = false;
            }
        }

        private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CmbCategory.SelectedIndex == 0)
            {
                StackMen.Visibility = Visibility.Visible;
                StackWomen.Visibility = Visibility.Hidden;
                StackChildren.Visibility = Visibility.Hidden;
            }
            else if (CmbCategory.SelectedIndex == 1)
            {
                StackWomen.Visibility = Visibility.Visible;
                StackMen.Visibility = Visibility.Hidden;
                StackChildren.Visibility = Visibility.Hidden;
            }
            else if (CmbCategory.SelectedIndex == 2)
            {
                StackChildren.Visibility = Visibility.Visible;
                StackWomen.Visibility = Visibility.Hidden;
                StackMen.Visibility = Visibility.Hidden;
            }
        }

        private void Writeinfile(string services, string time, string name, string category, int age, int height, string credit)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                string s = services;
                bw.Write(services);
                string t = time;
                bw.Write(t);
                string n = name;
                bw.Write(n);
                string ca = category;
                bw.Write(ca);
                int a = age;
                bw.Write(a);
                int h = height;
                bw.Write(height);
                string c = credit;
                bw.Write(c);

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.ToString());
            }
            finally
            {
                fs.Close();
            }


        }

        private void ReadInFile(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                
                string s = br.ReadString();
                string t = br.ReadString();
                string n = br.ReadString();
                string ca = br.ReadString();
                int a = br.ReadInt32();
                int h = br.ReadInt32();
                string c = br.ReadString();

                Appointment cust = new Appointment(s, t, n, ca, a, h, c);

                al.Add(cust);

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.ToString());
            }
            finally
            {
                fs.Close();
            }
        }

        private void Showbttn_Click(object sender, RoutedEventArgs e)
        {

            al.Sort();

            for (int i = 0; i < al.Count(); i++)
            {
                txtblck.Text += "Appointment #" + (i + 1) + "\n";
                txtblck.Text += al[i] + "\n";
            }

        }
    }
}
