using System.Collections.Generic;
using System.Linq;
using TutorialCoreJWT.Models;

namespace TutorialCoreJWT.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        => users.Select(x => x.WithoutPasswords());

        public static User WithoutPasswords(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}