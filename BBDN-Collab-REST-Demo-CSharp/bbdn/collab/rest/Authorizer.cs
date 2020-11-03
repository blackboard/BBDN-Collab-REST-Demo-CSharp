using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CollabRestDemo.bbdn.collab.rest.models;
using JWT;
using JWT.Builder;
using JWT.Algorithms;

namespace CollabRestDemo.bbdn.collab.rest
{
    public class Authorizer
    {
        HttpClient client;

        private string CreateToken(string secret)
        {
            secret = secret ?? "";

            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                .WithSecret(secret)
                .AddClaim("iss", Constants.KEY)
                .AddClaim("sub", Constants.KEY)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds())
                .Encode();

            Console.WriteLine(token);

            return token;
        }

        public async Task<Token> Authorize()
        {
            var assertion = CreateToken(Constants.SECRET);

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