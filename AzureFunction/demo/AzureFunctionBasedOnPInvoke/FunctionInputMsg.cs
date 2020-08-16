using Newtonsoft.Json;

namespace AzureFunctionBasedOnPInvoke
{
    public class FunctionInputMsg
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { set; get; }

        [JsonProperty(PropertyName = "destination", Required = Required.Always)]
        public string Destination { set; get; }
    }
}
