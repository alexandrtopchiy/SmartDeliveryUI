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
    public partial class Form3 : Form
    {
        SmartDeliveryData sd;
        Thread th;
        public Form3(SmartDeliveryData sData)
        {
            sd = sData;
            InitializeComponent();
            UploadDataToEdit();
        }

        async  private void UploadDataToEdit()
        {
            ProfileInfo pr;

            pr = await sd.GetClientProfile();

            firstNameEDIT_textBox.Text = pr.Personal_Data.p_name;
            secondNameEDIT_textBox.Text = pr.Personal_Data.p_secondname;
            surnameEDIT_textBox.Text = pr.Personal_Data.p_surname;
            birthDateEDIT_textBox.Text = pr.Personal_Data.birth_date.ToString();
            emailEDIT_textBox.Text = pr.Personal_Data.email;
            phoneNumberEDIT_textBox.Text = pr.Personal_Data.phone_number;
        }

        async private void saveNewProfile_button_Click(object sender, EventArgs e)
        {
            PersonalDataModel newProfile = new PersonalDataModel();

            newProfile.p_name = firstNameEDIT_textBox.Text;
            newProfile.p_secondname = secondNameEDIT_textBox.Text;
            newProfile.p_surname = surnameEDIT_textBox.Text;
            newProfile.birth_date = Convert.ToDateTime(birthDateEDIT_textBox.Text);
            newProfile.email = emailEDIT_textBox.Text;  
            newProfile.phone_number = phoneNumberEDIT_textBox.Text;

            string res = await sd.UpdateMyProfile(newProfile);

            if (res == "\"Success\"")
            {
                MessageBox.Show("Profile updated successfully!");
                this.Close();
                th = new Thread(OpenSecondForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

            } else
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

        private void goBack_button_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenSecondForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
