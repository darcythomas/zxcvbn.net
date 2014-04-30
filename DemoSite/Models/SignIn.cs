using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using zxcvbn.net;

namespace DemoSite.Controllers
{
    public class SignIn
    {
        
        [Required]
        public String UserName { get; set; }
        [StrongPassword]
        public String Password { get; set; }       
    }
}
