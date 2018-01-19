using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActiveCampaign.Models
{
    public class NewContactModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string OrgName { get; set; }
    }
}