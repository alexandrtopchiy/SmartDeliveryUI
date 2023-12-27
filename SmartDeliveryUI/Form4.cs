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
    public partial class Form4 : Form
    {
        SmartDeliveryData sd;
        Thread th;
        public Form4(SmartDeliveryData sdata)
        {
            sd=sdata;
            InitializeComponent();
            UploadCardData();
        }

        async private void UploadCardData()
        {
            CardDataModel card;

            card = await sd.GetCardInfo();

            cardNumberEDIT_textBox.Text = card.card_number.ToString();
            expDateEDIT_textBox.Text = card.expiring_date.ToString();
            cvvEDIT_textBox.Text = card.cvv.ToString();
            bankEDIT_textBox.Text = card.bank_name.ToString();

        }

        async private void saveCardData_button_Click(object sender, EventArgs e)
        {
            CardDataModel newCard = new CardDataModel();

            newCard.card_number = cardNumberEDIT_textBox.Text;
            newCard.expiring_date = Convert.ToDateTime(expDateEDIT_textBox.Text);
            newCard.cvv = Convert.ToInt32(cvvEDIT_textBox.Text);
            newCard.bank_name = bankEDIT_textBox.Text;

            string res = await sd.UpdateMyCard(newCard);

            if (res == "\"Success\"")
            {
                MessageBox.Show("Card data updated successfully!");
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
        private void OpenSecondForm()
        {
            Application.Run(new Form2(sd));
        }

        private void returnToMenu_button_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenSecondForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
