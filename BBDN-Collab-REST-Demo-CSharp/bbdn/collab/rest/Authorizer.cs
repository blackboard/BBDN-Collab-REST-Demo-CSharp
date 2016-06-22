using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CollabRestDemo.bbdn.collab.rest.models;

namespace CollabRestDemo.bbdn.collab.rest
{
    public class Authorizer
    {
        HttpClient client;

        private string CreateToken(string secret, double exp)
        {
            secret = secret ?? "";

            var payload = new Dictionary<string, object>()
            {
                { "iss", Constants.KEY },
                { "sub", Constants.KEY },
                { "exp", exp }
            };

            string token = JWT.JsonWebToken.Encode(payload, secret, JWT.JwtHashAlgorithm.HS256);
            Console.WriteLine(token);
            return (token);
        }

        public async Task<Token> Authorize()
        {
            var unixEpoch = new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var exp = Math.Round((System.DateTime.UtcNow - unixEpoch).TotalSeconds + 5);


            var assertion = CreateToken(Constants.SECRET, exp);


            client = new HttpClient();

            var endpoint = new Uri(Constants.HOSTNAME + Constants.AUTH_PATH);
            Console.WriteLine("endpoint: {0}", endpoint);
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer"));
            postData.Add(new KeyValuePair<string, string>("assertion", assertion));
        
            Console.WriteLine("postData: {0}", postData.ToString());

            HttpContent body = new FormUrlEncodedContent(postData);

            Console.WriteLine("body: {0}", body.ToString());

            Token token = new Token();
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync(endpoint, body).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<Token>(content);
                    Console.WriteLine("Authorize() Token: " + token.ToString());
                }
                else
                {
                    Console.WriteLine(response.ToString());
                    response.EnsureSuccessStatusCode();
                }


            }
            catch (AggregateException agex)
            {
                Console.WriteLine(@"				ERROR {0}\n{1}", agex.Message, agex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return token;
        }

    }
}