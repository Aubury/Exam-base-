using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exam_base_
{
   [JsonObject(MemberSerialization.OptIn)]
   public class Request
    {
       
        [JsonProperty("ClientName")]
        public string ClientName { get; set; }
        [JsonProperty("Operation summ")]
        public int Sum;
    }
}
