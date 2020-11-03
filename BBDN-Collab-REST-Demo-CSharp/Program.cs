using CollabRestDemo.bbdn.collab.rest;
using CollabRestDemo.bbdn.collab.rest.helpers;
using CollabRestDemo.bbdn.collab.rest.models;
using CollabRestDemo.bbdn.collab.rest.services;
using Nito.AsyncEx;
using System;
using System.Threading.Tasks;

namespace CollabRestDemo
{
    class MainClass
    {
        private static Token token = new Token();

        public static void Main(string[] args)
        {

            try
            {
                AsyncContext.Run(() => MainAsync());
            }
            catch (AggregateException agex)
            {
                Console.WriteLine("AggregateException: " + agex.Message + " " + agex.InnerException);
            }
            catch (InvalidOperationException ioex)
            {
                Console.WriteLine("InvalidOperationException: " + ioex.Message + " " + ioex.InnerException);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message + " " + ex.InnerException);
            }
        }

        static async Task MainAsync()
        {


            Authorizer authorizer = new Authorizer();

            Console.WriteLine("calling authorize()");

            token = await authorizer.Authorize();

            Console.WriteLine("MainAsync(): Token=" + token.ToString());


            UserService userService = new UserService(token);

            User newUser = UserHelper.GenerateObject();
            User user = await userService.CreateUser(newUser);
            Console.WriteLine("User Created: " + user.ToString());

            var sessionService = new SessionService(token);

            Session newSession = SessionHelper.GenerateObject();
            Session session = await sessionService.CreateSession(newSession);
            Console.WriteLine("Session Created: " + session.ToString());
        }
    }       
}
