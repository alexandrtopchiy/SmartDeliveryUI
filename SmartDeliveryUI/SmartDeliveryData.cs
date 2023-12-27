using Newtonsoft.Json;
using SmartDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace SmartDeliveryUI
{
    public class SmartDeliveryData
    {
        HttpClient httpClient = new HttpClient();
       public int token;
       public int client_data_ID;
       public int client_card_ID;
        public SmartDeliveryData() {}
         
       async public Task<bool> Authorize(string login, string password)
        {
            try
            {               
                var res = await httpClient.GetAsync($"https://localhost:44303/api/Auth/GetClientToken?login={login}&password={password}");
                var content = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<AuthModel>>(content);
               
                if (result != null)
                {
                    token = result[0].client_ID;
                    return true;
                } else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        async public Task<ProfileInfo> GetClientProfile()
        {
            try
            {
                var res = await httpClient.GetAsync($"https://localhost:44303/api/Profile/GetClientProfile?token={this.token}");
                var content = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<ProfileInfo>>(content);

                client_data_ID = result[0].data_ID;
                client_card_ID = result[0].card_ID;

                if (result == null)
                {
                    throw new InvalidOperationException("Error.Collection is empty");
                }

                return result[0];
     
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<ProfileInfo>(null);
                
            }
        }

        async public Task<CardDataModel> GetCardInfo()
        {
            try
            {
                var res = await httpClient.GetAsync($"https://localhost:44303/api/Profile/GetCardData?card_ID={client_card_ID}");
                var content = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<CardDataModel>>(content);
                
                if (result == null)
                {
                    throw new InvalidOperationException("Error.Collection is empty");
                }

                return result[0];
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<CardDataModel>(null);

            }
        }

        async public Task<string> PayForPackage(int receipt_ID)
        {
            try
            {
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Package/PayForPackage?receipt_ID={receipt_ID}", null);
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }

        }
        async public Task<string> UpdateMyProfile(PersonalDataModel profile)
        {
            try
            {
                profile.data_ID = client_data_ID;
                StringContent content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Profile/UpdateMyProfile", content);

                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }

        }
        async public Task<string> UpdateMyCard(CardDataModel card)
        {        
            try
            {
                card.card_ID = client_card_ID;
                StringContent content = new StringContent(JsonConvert.SerializeObject(card), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Profile/UpdateBankCard", content);

                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }

        }

        async public Task<List<PackageModel>> GetPackageInfo(string status)
        {
            try
            {
                var res = await httpClient.GetAsync($"https://localhost:44303/api/Package/GetPackageInfo?client_ID={token}&status={status}");
                var content = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<PackageModel>>(content);

                if (result == null)
                {
                    throw new InvalidOperationException("Error.Collection is empty");
                }

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<List<PackageModel>>(null);

            }
        }

        async public Task<SenderModel> GetSenderInfo(int sender_ID)
        {
            try
            {
                var res = await httpClient.GetAsync($"https://localhost:44303/api/Package/GetSenderInfo?sender_ID={sender_ID}");
                var content = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<SenderModel>>(content);

                if (result == null)
                {
                    throw new InvalidOperationException("Error.Collection is empty");
                }

                return result[0];

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<SenderModel>(null);

            }
        }

        async public Task<CourierModel> GetCourierInfo(int courier_ID)
        {
            try
            {
                var res = await httpClient.GetAsync($"https://localhost:44303/api/Package/GetCourierInfo?courier_ID={courier_ID}");
                var content = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<CourierModel>>(content);

                if (result == null)
                {
                    throw new InvalidOperationException("Error.Collection is empty");
                }

                return result[0];

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<CourierModel>(null);

            }
        }

        async public Task<string> requestCourier(int package_ID, string adress)
        {
            Random random = new Random();
            int courier_ID = random.Next(1, 3);

            try
            {
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Package/RequestCourier?package_ID={package_ID}&courier_ID={courier_ID}&adress={adress}", null);
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }

        }

        async public Task<List<int>> GetPackageDataReceiptPackageSenderMaxID()
        {
            try
            {
                var res = await httpClient.GetAsync($"https://localhost:44303/api/Package/GetPackageDataReceiptPackageSenderPersonalMaxID");
                var content = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<int>>(content);

                if (result == null)
                {
                    throw new InvalidOperationException("Error.Collection is empty");
                }

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<List<int>>(null);

            }
        }

        async public Task<List<DepartmentModel>> GetAvaliableDepartmentData()
        {
            try
            {
                var res = await httpClient.GetAsync($"https://localhost:44303/api/Package/GetAvaliableDepartmentsList");
                var content = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<DepartmentModel>>(content);

                if (result == null)
                {
                    throw new InvalidOperationException("Error.Collection is empty");
                }

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<List<DepartmentModel>>(null);

            }
        }

        async public Task<string> AddNewPackageData(PackageDataModel model)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Package/AddNewPackageData", content);

                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }
        }

        async public Task<string> AddNewPersonalData(PersonalDataModel model)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Package/AddNewPersonalData", content);

                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }
        }

        async public Task<string> AddNewReceiptData(ReceiptModel model)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Package/AddNewReceiptData", content);

                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }
        }

        async public Task<string> AddNewSenderData(SenderModel model)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Package/AddNewSenderData", content);

                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }
        }

        async public Task<string> AddNewPackage(PackageModel model)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"https://localhost:44303/api/Package/AddNewPackage", content);

                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult<string>(null);
            }
        }
    }
}
