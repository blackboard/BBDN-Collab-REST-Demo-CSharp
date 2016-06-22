namespace CollabRestDemo.bbdn.collab.rest.models
{
    public class Token
    {
        public string access_token { get; set; }

        public string expires_in { get; set; }

        public override string ToString()
        {
            return ("{  \"access_token\" : \"" + access_token + "\", \"expires_in\" : \"" + expires_in + "\"   }");
        }

    }
}
