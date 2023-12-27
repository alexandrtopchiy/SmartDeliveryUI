using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDeliveryUI
{
    public partial class Form5 : Form
    {
        SmartDeliveryData sd;
        List<PackageModel> packages;
        int currentItem;
        public Form5(SmartDeliveryData sdata, List<PackageModel> pack, int current)
        {
            sd = sdata;
            packages = pack;
            currentItem = current;
            InitializeComponent();
            ShowMorePackageInfo();
        }

       async private void ShowMorePackageInfo()
        {
            SenderModel sender;
            

            sender = await  sd.GetSenderInfo(packages[currentItem].sender_ID);

            if (packages[currentItem].courier_ID != null)
            {
                CourierModel courier;
                courier = await sd.GetCourierInfo(packages[currentItem].courier_ID.Value);

                courierFirstName_textBox.Text = courier.Personal_Data.p_name;
                courierSecondName_textBox.Text = courier.Personal_Data.p_surname;
                courierPhoneNumber_textBox.Text = courier.Personal_Data.phone_number;
                courierRating_textBox.Text = courier.rating.ToString();
            } else
            {
                courier_label.Text = "You didn't order a courier";

                courierFirstName_textBox.Text = "No info";
                courierSecondName_textBox.Text = "No info";
                courierPhoneNumber_textBox.Text = "No info";
                courierRating_textBox.Text = "No info";

            }

            weight_textBox.Text = packages[currentItem].Package_Data.weights.ToString();
            volume_textBox.Text = packages[currentItem].Package_Data.volume.ToString();

            depCode_textBox.Text = packages[currentItem].Department.department_ID.ToString();
            depAdress_textBox.Text = packages[currentItem].Department.adress.ToString();
            depCity_textBox.Text= packages[currentItem].Department.city.ToString();
            index_textBox.Text = packages[currentItem].Department.indx;
            phone_textBox.Text = packages[currentItem].Department.phone_number.ToString();
            workTime_textBox.Text = packages[currentItem].Department.work_time;

            if (packages[currentItem].delivery_type == "Awaiting")
            {
                label6.Text = "Receiver data:";
            }

            if (sender != null)
            {
                senderFirstName_textBox.Text = sender.Personal_Data.p_name;
                senderSecondName_textBox.Text = sender.Personal_Data.p_secondname;
                senderSurname_textBox.Text = sender.Personal_Data.p_surname;
                senderPhoneNumber_textBox.Text = sender.Personal_Data.phone_number;
            } else
            {
                senderFirstName_textBox.Text = "No info";
                senderSecondName_textBox.Text = "No info";
                senderSurname_textBox.Text = "No info";
                senderPhoneNumber_textBox.Text = "No info";
            }
         


        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
