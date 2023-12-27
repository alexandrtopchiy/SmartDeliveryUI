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
    public partial class Form8 : Form
    {
        SmartDeliveryData sd;
        PackageModel newPdModel = new PackageModel();
        List<DepartmentModel> departments;
        Thread th;

        int newDeclarationNumber;
        int newPackageDataID;
        int newReceiptID;
        int newSenderID;
        int newPersonalDataID;
        public Form8(SmartDeliveryData sdata)
        {
            InitializeComponent();
            this.sd = sdata;
        }

         private async void newPackage_button_Click(object sender, EventArgs e)
        {
            PackageDataModel newPackageDataModel = new PackageDataModel();
            ReceiptModel newReceiptModel = new ReceiptModel();
            PersonalDataModel newPersonalDataModel = new PersonalDataModel();
            SenderModel newSenderModel = new SenderModel();

            newPackageDataModel.package_data_ID = newPackageDataID;
            newPackageDataModel.send_date = Convert.ToDateTime(sendDate_comboBox.Text);
            newPackageDataModel.arrival_date = Convert.ToDateTime(newPackageDataModel.send_date.AddDays(2));
            newPackageDataModel.package_status = "In department";
            newPackageDataModel.descript = newDescription_textBox.Text;
            newPackageDataModel.weights = Convert.ToInt32(newWeight_textBox.Text);
            newPackageDataModel.volume = Convert.ToInt32(newVolume_textBox.Text);

            newReceiptModel.receipt_ID = newReceiptID;
            newReceiptModel.payment_status = "Not payed";
            newReceiptModel.payment_method = "Cash";
            newReceiptModel.delivery_price = 100;
            newReceiptModel.package_price = Convert.ToInt32(newPackagePrice_textBox.Text);

            newPersonalDataModel.data_ID = newPersonalDataID;
            newPersonalDataModel.p_name = newFirstName_textBox.Text;
            newPersonalDataModel.p_secondname = newSecondName_textBox.Text;
            newPersonalDataModel.p_surname = newSurname_textBox.Text;
            newPersonalDataModel.phone_number = newPhoneNumber_textBox.Text;
            newPersonalDataModel.birth_date = Convert.ToDateTime("1900-01-01");
            newPersonalDataModel.email = "Uknown";

            newSenderModel.sender_ID = newSenderID;
            newSenderModel.data_ID = newPersonalDataID;

            newPdModel.department_ID = Convert.ToInt32(department_comboBox.Text);

            string res = await AddNewData(newPackageDataModel, newReceiptModel, newPersonalDataModel, newSenderModel);
            if (res == "Success")
            {
                MessageBox.Show("Package successfully created");
            } else
            {
                MessageBox.Show("Error");
            }
        }

       async  private Task<string> AddNewData(PackageDataModel newPackageDataModel, ReceiptModel newReceiptModel, PersonalDataModel newPersonalDataModel, SenderModel newSenderModel)
        {
            string res = null;
            try
            {
               res= await sd.AddNewPackageData(newPackageDataModel);
                if (res != null)
                {
                    res = await sd.AddNewReceiptData(newReceiptModel);
                    if (res != null)
                    {
                        res = await sd.AddNewPersonalData(newPersonalDataModel);
                        if  (res != null)
                        {
                            res = await sd.AddNewSenderData(newSenderModel);
                            if (res != null)
                            {
                                res = await sd.AddNewPackage(newPdModel);
                                if (res != null)
                                {
                                    return "Success";
                                }
                            }
                        }
                    }

                } 
                return null;
            }
            catch (Exception)
            {
                return null;

                throw;
            }

        }

        async private Task<List<DepartmentModel>> GetAvaliableDepartments()
        {
            try
            {
                return await sd.GetAvaliableDepartmentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return await Task.FromResult<List<DepartmentModel>>(null);
            }
           
        }

        async private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                List<int> maxIDs = await sd.GetPackageDataReceiptPackageSenderMaxID();
                departments  = await GetAvaliableDepartments();

                if (maxIDs != null && departments != null)
                {
                    newDeclarationNumber = maxIDs[2] + 1;
                    newPackageDataID = maxIDs[0] + 1;
                    newReceiptID = maxIDs[1] + 1;
                    newSenderID = maxIDs[3] + 1;
                    newPersonalDataID = maxIDs[4] + 1;

                    string deliveryType = "Awaiting";

                    newPdModel.client_ID = sd.token;
                    newPdModel.package_ID = newDeclarationNumber;
                    newPdModel.package_data_ID = newPackageDataID;
                    newPdModel.receipt_ID = newReceiptID;
                    newPdModel.sender_ID = newSenderID;
                    newPdModel.delivery_type = deliveryType.ToString();

                    newPackageID_textBox.Text = newDeclarationNumber.ToString();
                    newDeliveryType_textBox.Text = deliveryType.ToString();

                    DateTime today = DateTime.Today;

                    sendDate_comboBox.Items.Add(today.ToString("yyyy/MM/dd"));

                    for (int i = 1; i < 5; i++)
                    {
                        sendDate_comboBox.Items.Add((today.AddDays(i)).ToString("yyyy/MM/dd"));
                    }
                    for (int i = 0; i < departments.Count; i++)
                    {
                        department_comboBox.Items.Add(departments[i].department_ID).ToString();
                    }

                }          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
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

    }
}
