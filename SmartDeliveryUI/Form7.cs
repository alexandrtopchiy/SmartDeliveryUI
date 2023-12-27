using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDeliveryUI
{
    public partial class Form7 : Form
    {
        Thread th;
        SmartDeliveryData sd;
        List<PackageModel> packages;
        int currentItem;
        public Form7(SmartDeliveryData sdata, List<PackageModel> pk, int cur)
        {
            sd = sdata;
            packages = pk;
            currentItem = cur;
            InitializeComponent();

            DateTime today = DateTime.Today;

            courierDate_comboBox.Items.Add(today.ToString("yyyy/MM/dd"));

            for (int i = 1; i < 5; i++)
            {
                courierDate_comboBox.Items.Add((today.AddDays(i)).ToString("yyyy/MM/dd"));
            }
        }
        private void goBack_button_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenSecondForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenSecondForm()
        {
            Application.Run(new Form2(sd));
        }

        private void submitCourier_button_Click(object sender, EventArgs e)
        {
            string city = cityCourier_textBox.Text.ToString();
            string adress = adressCourier_textBox.Text.ToString();
            string date = courierDate_comboBox.Text.ToString();
            string time = comboBox.Text.ToString();

            string all = $"Courier({city + ";" + adress})";
            try
            {
                string result = sd.requestCourier(packages[currentItem].package_ID, all).ToString();
                if (result != null)
                {
                    MessageBox.Show("Courier successfully requested\n" +
                        "To see Courier data click 'More information'");
                    this.Close();
                    th = new Thread(OpenSecondForm);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                } else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
