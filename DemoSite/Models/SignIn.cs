using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DemoSite.Controllers
{
    public class SignIn
    {
        [Required]
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean RememberMe { get; set; }
    }
}
