using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureFunctionBasedOnPInvoke
{
    public class BasicFuntionInput
    {
        [JsonProperty(PropertyName = "input", Required = Required.Always)]
        public JObject Input { get; set; }
        [JsonProperty(PropertyName = "context", Required = Required.Always)]
        public JObject Context { get; set; }
    }
}
