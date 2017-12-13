using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exam_base_
{
   [JsonObject(MemberSerialization.OptIn)]
    class Request
    {
        Client cl;
        [JsonProperty("ClientName")]
        public string ClientName { get; set; }
        [JsonProperty("Operation summ")]
        public int Sum;
    }
}
