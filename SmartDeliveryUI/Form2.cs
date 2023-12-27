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
    public partial class Form2 : Form
    {
        Point lastPoint;
        SmartDeliveryData sd;
        Thread th;

        List<PackageModel> packages;
        List<PackageModel> history;
        int currentItem;
        int totalItem;

        int currentItemHISTORY;
        int totalItemHISTORY;

        public Form2(SmartDeliveryData sData)
        {
            sd = sData;
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            UploadPersonalData();
            UploadActivePackageData();
            UploadHelpInfo();
        }

        async private void UploadActivePackageData()
        {
            
            packages = await sd.GetPackageInfo("In department");
            history = await sd.GetPackageInfo("Received");

            currentItem = 0;
            totalItem = packages.Count;

            currentItemHISTORY = 0;
            totalItemHISTORY = history.Count;

            if (packages!= null)
            {
                packageID_textBox.Text = packages[0].package_ID.ToString();
                deliveyType_textBox.Text = packages[0].delivery_type;
                sendDate_textBox.Text = packages[0].Package_Data.send_date.ToString().Substring(0, 10);
                arrivalDate_textBox.Text = packages[0].Package_Data.arrival_date.ToString().Substring(0, 10);
                description_textBox.Text = packages[0].Package_Data.descript;
                departmentID_textBox.Text = packages[0].Department.department_ID.ToString();
                status_textBox.Text = packages[0].Package_Data.package_status;
                adress_textBox.Text = packages[0].Department.adress;
                cityID_textBox.Text = packages[0].Department.city;
                deliveryPrice_textBox.Text = packages[0].Receipt.delivery_price.ToString();
                packagePrice_textBox.Text = packages[0].Receipt.package_price.ToString();
                paymentStatus_textBox.Text = packages[0].Receipt.payment_status;

                packageNumber_texBox.Text = (currentItem + 1).ToString();
                packageTotalNumber_texBox.Text = totalItem.ToString();
            } else
            {
                packageID_textBox.Text = "No info";
                deliveyType_textBox.Text = "No info";
                sendDate_textBox.Text = "No info";
                arrivalDate_textBox.Text = "No info";
                description_textBox.Text = "No info";
                departmentID_textBox.Text = "No info";
                status_textBox.Text = "No info";
                adress_textBox.Text = "No info";
                cityID_textBox.Text = "No info";
                deliveryPrice_textBox.Text = "No info";
                packagePrice_textBox.Text = "No info";
                paymentStatus_textBox.Text = "No info";

                packageNumber_texBox.Text = "No info";
                packageTotalNumber_texBox.Text = "No info";
            }

            if (history != null)
            {
                declarationCodeHISTORY_textBox.Text = history[0].package_ID.ToString();
                deliveryTypeHISTORY_textBox.Text = history[0].delivery_type;
                sendDateHISTORY_textBox.Text = history[0].Package_Data.send_date.ToString().Substring(0, 10);
                arrivalDateHISTORY_textBox.Text = history[0].Package_Data.arrival_date.ToString().Substring(0, 10);
                descriptionHISTORY_textBox.Text = history[0].Package_Data.descript;
                departmentCodeHISTORY_textBox.Text = history[0].Department.department_ID.ToString();
                statusHISTORY_textBox.Text = history[0].Package_Data.package_status;
                adressHISTORY_textBox.Text = history[0].Department.adress;
                cityHISTORY_textBox.Text = history[0].Department.city;
                deliveryPriceHISTORY_textBox.Text = history[0].Receipt.delivery_price.ToString();
                packagePiceHISTORY_textBox.Text = history[0].Receipt.package_price.ToString();
                paymentStatusHISTORY_textBox.Text = history[0].Receipt.payment_status;

                currentHISTORY_textBox.Text = (currentItemHISTORY + 1).ToString();
                totalHISTORY_textBox.Text = totalItemHISTORY.ToString();
            } else
            {
                declarationCodeHISTORY_textBox.Text = "No info";
                deliveryTypeHISTORY_textBox.Text = "No info";
                sendDateHISTORY_textBox.Text = "No info";
                arrivalDateHISTORY_textBox.Text = "No info";
                descriptionHISTORY_textBox.Text = "No info";
                departmentCodeHISTORY_textBox.Text = "No info";
                statusHISTORY_textBox.Text = "No info";
                adressHISTORY_textBox.Text = "No info";
                cityHISTORY_textBox.Text = "No info";
                deliveryPriceHISTORY_textBox.Text = "No info";
                packagePiceHISTORY_textBox.Text = "No info";
                paymentStatusHISTORY_textBox.Text = "No info";

                currentHISTORY_textBox.Text = "No info";
                totalHISTORY_textBox.Text = "No info";
            }

        }

        async private void UploadPersonalData()
        {
            ProfileInfo pr;

            pr = await sd.GetClientProfile();

            firstName_textBox.Text = pr.Personal_Data.p_name;
            secondName_textBox.Text = pr.Personal_Data.p_secondname;
            surname_textBox.Text = pr.Personal_Data.p_surname;
            birthDate_textBox.Text = pr.Personal_Data.birth_date.ToString().Substring(0,10);
            email_textBox.Text = pr.Personal_Data.email;
            phoneNumber_textBox.Text = pr.Personal_Data.phone_number;

            UploadCardData();
        }

        async private void UploadCardData()
        {
            CardDataModel card;

            card = await sd.GetCardInfo();

            cardNumber_textBox.Text = card.card_number.ToString();
            expDate_textBox.Text = card.expiring_date.ToString().Substring(0, 10);
            cvv_textBox.Text = card.cvv.ToString();
            bank_textBox.Text = card.bank_name.ToString();
        }


        private void logout_button_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenFirstForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void changeCard_button_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenFourthForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();


        }

        private void editProfile_button_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenThirdForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

          
        }
      
        private void nextPackage_button_Click(object sender, EventArgs e)
        {
            if (currentItem < totalItem-1)
            {
                currentItem++;

                packageID_textBox.Text = packages[currentItem].package_ID.ToString();
                deliveyType_textBox.Text = packages[currentItem].delivery_type;
                sendDate_textBox.Text = packages[currentItem].Package_Data.send_date.ToString().Substring(0, 10);
                arrivalDate_textBox.Text = packages[currentItem].Package_Data.arrival_date.ToString().Substring(0, 10);
                description_textBox.Text = packages[currentItem].Package_Data.descript;
                departmentID_textBox.Text = packages[currentItem].Department.department_ID.ToString();
                status_textBox.Text = packages[currentItem].Package_Data.package_status;
                adress_textBox.Text = packages[currentItem].Department.adress;
                cityID_textBox.Text = packages[currentItem].Department.city;
                deliveryPrice_textBox.Text = packages[currentItem].Receipt.delivery_price.ToString();
                packagePrice_textBox.Text = packages[currentItem].Receipt.package_price.ToString();
                paymentStatus_textBox.Text = packages[currentItem].Receipt.payment_status;

                packageNumber_texBox.Text = (currentItem + 1).ToString();
                packageTotalNumber_texBox.Text = totalItem.ToString();


            }
        }

        private void previousPackage_button_Click(object sender, EventArgs e)
        {
            if (currentItem > 0)
            {
                currentItem--;

                packageID_textBox.Text = packages[currentItem].package_ID.ToString();
                deliveyType_textBox.Text = packages[currentItem].delivery_type;
                sendDate_textBox.Text = packages[currentItem].Package_Data.send_date.ToString().Substring(0, 10);
                arrivalDate_textBox.Text = packages[currentItem].Package_Data.arrival_date.ToString().Substring(0, 10);
                description_textBox.Text = packages[currentItem].Package_Data.descript;
                departmentID_textBox.Text = packages[currentItem].Department.department_ID.ToString();
                status_textBox.Text = packages[currentItem].Package_Data.package_status;
                adress_textBox.Text = packages[currentItem].Department.adress;
                cityID_textBox.Text = packages[currentItem].Department.city;
                deliveryPrice_textBox.Text = packages[currentItem].Receipt.delivery_price.ToString();
                packagePrice_textBox.Text = packages[currentItem].Receipt.package_price.ToString();
                paymentStatus_textBox.Text = packages[currentItem].Receipt.payment_status;

                packageNumber_texBox.Text = (currentItem + 1).ToString();
                packageTotalNumber_texBox.Text = totalItem.ToString();


            }
        }

        private void moreInfo_Button_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(sd, packages, currentItem);
            form5.Show();
        }

        private void payment_button_Click(object sender, EventArgs e)
        {
            if (packages[currentItem].Receipt.payment_status != "Payed")
            {
                this.Close();
                th = new Thread(OpenSixthForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            } else
            {
                MessageBox.Show("Package is already payed");
            }
        }

        private void orderCourier_button_Click(object sender, EventArgs e)
        {
            if (packages[currentItem].courier_ID == null && packages[currentItem].delivery_type != "Awaiting")
            {
                this.Close();
                th = new Thread(OpenSevenForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            } else
            {
                MessageBox.Show("You cant't order a courier!");
            }
        }

        private void newPackage_button_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenEightForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void nextHISTORY_button_Click(object sender, EventArgs e)
        {
            if (currentItemHISTORY < totalItemHISTORY - 1)
            {
                currentItemHISTORY++;

                declarationCodeHISTORY_textBox.Text = history[currentItemHISTORY].package_ID.ToString();
                deliveryTypeHISTORY_textBox.Text = history[currentItemHISTORY].delivery_type;
                sendDateHISTORY_textBox.Text = history[currentItemHISTORY].Package_Data.send_date.ToString().Substring(0, 10);
                arrivalDateHISTORY_textBox.Text = history[currentItemHISTORY].Package_Data.arrival_date.ToString().Substring(0, 10);
                descriptionHISTORY_textBox.Text = history[currentItemHISTORY].Package_Data.descript;
                departmentCodeHISTORY_textBox.Text = history[currentItemHISTORY].Department.department_ID.ToString();
                statusHISTORY_textBox.Text = history[currentItemHISTORY].Package_Data.package_status;
                adressHISTORY_textBox.Text = history[currentItemHISTORY].Department.adress;
                cityHISTORY_textBox.Text = history[currentItemHISTORY].Department.city;
                deliveryPriceHISTORY_textBox.Text = history[currentItemHISTORY].Receipt.delivery_price.ToString();
                packagePiceHISTORY_textBox.Text = history[currentItemHISTORY].Receipt.package_price.ToString();
                paymentStatusHISTORY_textBox.Text = history[currentItemHISTORY].Receipt.payment_status;

                currentHISTORY_textBox.Text = (currentItemHISTORY + 1).ToString();
                totalHISTORY_textBox.Text = totalItemHISTORY.ToString();


            }
        }

        private void prevHISTORY_button_Click(object sender, EventArgs e)
        {
            if (currentItemHISTORY > 0)
            {
                currentItemHISTORY--;

                declarationCodeHISTORY_textBox.Text = history[currentItemHISTORY].package_ID.ToString();
                deliveryTypeHISTORY_textBox.Text = history[currentItemHISTORY].delivery_type;
                sendDateHISTORY_textBox.Text = history[currentItemHISTORY].Package_Data.send_date.ToString().Substring(0, 10);
                arrivalDateHISTORY_textBox.Text = history[currentItemHISTORY].Package_Data.arrival_date.ToString().Substring(0, 10);
                descriptionHISTORY_textBox.Text = history[currentItemHISTORY].Package_Data.descript;
                departmentCodeHISTORY_textBox.Text = history[currentItemHISTORY].Department.department_ID.ToString();
                statusHISTORY_textBox.Text = history[currentItemHISTORY].Package_Data.package_status;
                adressHISTORY_textBox.Text = history[currentItemHISTORY].Department.adress;
                cityHISTORY_textBox.Text = history[currentItemHISTORY].Department.city;
                deliveryPriceHISTORY_textBox.Text = history[currentItemHISTORY].Receipt.delivery_price.ToString();
                packagePiceHISTORY_textBox.Text = history[currentItemHISTORY].Receipt.package_price.ToString();
                paymentStatusHISTORY_textBox.Text = history[currentItemHISTORY].Receipt.payment_status;

                currentHISTORY_textBox.Text = (currentItemHISTORY + 1).ToString();
                totalHISTORY_textBox.Text = totalItemHISTORY.ToString();
            }
        }

        private void morePackageInfoHISTORY_button_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(sd, history, currentItemHISTORY);
            form5.Show();
        }


        /// <summary>
        /// ///
        /// </summary>
        /// 
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void OpenFirstForm()
        {
            Application.Run(new Form1());
        }
        private void OpenThirdForm()
        {
            Application.Run(new Form3(sd));
        }
        private void OpenFourthForm()
        {
            Application.Run(new Form4(sd));
        }
        private void OpenSixthForm()
        {
            Application.Run(new Form6(sd, packages, currentItem));
        }
        private void OpenSevenForm()
        {
            Application.Run(new Form7(sd, packages, currentItem));
        }
        private void OpenEightForm()
        {
            Application.Run(new Form8(sd));
        }

        private void UploadHelpInfo()
        {
            richTextBox1.Text = "This application was developed by Oleksandr Topchiy\n" +
                "Group: IK-11\n" +
                "Faculty: Faculty of Informatics and Software Engineering\n" +
                "Course: 3\n" +
                "Year: 2023" +
                "\n" +
                "\n" +
                "If you have problems with application you can contact the developer via gmail: o.topchiy@lll.kpi.ua";
        }
    }
}
