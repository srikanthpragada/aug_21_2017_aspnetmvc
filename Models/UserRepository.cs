using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class UserRepository
    {
        public static User [] GetUser()
        {
            return new User[] {
                   new User { Username = "bill", Password = "bill"},
                   new User { Username = "steve", Password = "steve"},
                   new User { Username = "tom", Password = "tom"}
            };
        }
    }
}