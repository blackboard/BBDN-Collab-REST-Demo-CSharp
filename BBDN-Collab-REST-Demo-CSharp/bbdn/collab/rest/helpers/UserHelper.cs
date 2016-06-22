using CollabRestDemo.bbdn.collab.rest.models;

namespace CollabRestDemo.bbdn.collab.rest.helpers
{
    class UserHelper
    {
        public static User GenerateObject()
        {
            User user = new User();

            user.firstName = "John";
            user.lastName = "Glenn";
            user.displayName = "Senator John Glenn";
            user.email = "john.glenn@outerspace.com";
            user.extId = user.email;

            return (user);
        }

    }
}
