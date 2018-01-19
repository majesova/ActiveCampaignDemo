using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActiveCampaign.Models
{
    public class AddContactResponse
    {
        public int subscriber_id { get; set; }
        public int sendlast_should { get; set; }
        public int sendlast_did { get; set; }
        public int result_code { get; set; }
        public string result_message { get; set; }
        public string result_output { get; set; }
        
    }



}