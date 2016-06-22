namespace CollabRestDemo.bbdn.collab.rest.models
{
    class User
    {
        public string lastName { get; set; }

        public string firstName { get; set; }

        public string displayName { get; set; }

        public string email { get; set; }

        public string id { get; set; }

        public string extId { get; set; }

        public System.DateTime created { get; set; }

        public System.DateTime modified { get; set; }

        public override string ToString()
        {
            return ("{  \"lastName\" : \"" + lastName + "\"," +
                        "\"firstName\" : \"" + firstName + "\"," +
                        "\"displayName\" : \"" + displayName + "\"," +
                        "\"email\" : \"" + email + "\"," +
                        "\"id\" : \"" + id + "\"," +
                        "\"extId\" : \"" + extId + "\"," +
                        "\"created\" : \"" + created.ToString() + "\"," +
                        "\"modified\" : \"" + modified.ToString() + "\"     }");

        }
    }
}
