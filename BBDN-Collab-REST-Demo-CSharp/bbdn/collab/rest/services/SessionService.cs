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
    class SessionService
    {
        HttpClient client;


        public SessionService(Token token)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
        }

        public async Task<Session> CreateSession(Session newSession)
        {
            Session session = new Session();
            var uri = new Uri(Constants.HOSTNAME + Constants.SESSION_PATH);

            try
            {
                var json = JsonConvert.SerializeObject(newSession);
                var body = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, body);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    session = JsonConvert.DeserializeObject<Session>(content);
                    Debug.WriteLine(@"				Session successfully created.");
                }
                else
                {
                    Debug.WriteLine(@"              Creation Failed: " + response.StatusCode + " " + response.ReasonPhrase +" " + response.Content.ToString());
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return session;
        }
    }
}