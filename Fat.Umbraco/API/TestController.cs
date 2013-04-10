using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Fat.Umbraco.API
{
    public class TestController : ApiController
    {
        public Message Get()
        {
            return new Message
                {
                    Name = "this is a test"
                };
        }
    }

    public class Message
    {

        public string Name { get; set; }

    }
}