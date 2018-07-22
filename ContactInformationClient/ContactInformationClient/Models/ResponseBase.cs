using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactInformationClient.Models
{
    public class ResponseBase
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}