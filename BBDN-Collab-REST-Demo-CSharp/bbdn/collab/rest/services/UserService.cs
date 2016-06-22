using CollabRestDemo.bbdn.collab.rest.models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CollabRestDemo.bbdn.collab.rest.services
{
    class UserService
    {
        HttpClient client;


        public UserService(Token token)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
        }

        public async Task<User> CreateUser(User newUser)
        {
            User user = new User();
            var uri = new Uri(Constants.HOSTNAME + Constants.USER_PATH);

            try
            {
                var json = JsonConvert.SerializeObject(newUser);
                var body = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, body);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);
                    Debug.WriteLine(@"				User successfully created.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return user;
        }
    }
}
