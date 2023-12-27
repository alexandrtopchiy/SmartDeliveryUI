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
    public partial class Form6 : Form
    {
        SmartDeliveryData sd;
        List<PackageModel> packages;
        int currentItem;
        Thread th;

        public Form6(SmartDeliveryData sdata, List<PackageModel> pd, int item)
        {
            sd = sdata;
            packages = pd;
            currentItem = item;
            InitializeComponent();
        }

        private void makePayment_button_Click(object sender, EventArgs e)
        {
          DialogResult dialogResult = MessageBox.Show($"To confirm payemnt press 'Yes'\nIf you want to use different card press 'Change'", "Confirmation", MessageBoxButtons.YesNo);
          if (dialogResult == DialogResult.Yes)
            {
            try
                {
                    string result =  sd.PayForPackage(packages[currentItem].receipt_ID).ToString();
                    if (result != null)
                    {
                        MessageBox.Show("Payment made successfully!");
                        this.Close();
                        th = new Thread(OpenSecondForm);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();

                    }
                    else
                    {
                        MessageBox.Show("Error!");
                        this.Close();
                        th = new Thread(OpenSecondForm);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       async private Task<CardDataModel>  getCard()
        {
            CardDataModel card = await sd.GetCardInfo();

            return card;
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

        private void changeCard_button_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenFourthForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        private void OpenFourthForm()
        {
            Application.Run(new Form4(sd));
        }

        async private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                CardDataModel c = await getCard();
                delPrice_PAYMENT_textBox.Text = packages[currentItem].Receipt.delivery_price.ToString();
                devPrice_PAYMENT_textBox.Text = packages[currentItem].Receipt.package_price.ToString();
                totalPrice_PAYMENT_textBox.Text = (packages[currentItem].Receipt.package_price + packages[currentItem].Receipt.delivery_price).ToString();

                paymentCard_textBox.Text = c.card_number.ToString();
                paymentBank_textBox.Text = c.bank_name.ToString(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
