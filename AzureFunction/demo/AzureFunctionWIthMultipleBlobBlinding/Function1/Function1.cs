using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionWIthMultipleBlobBlinding
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static string Run(FunctionTriggerMsg functionTriggerMsg, TextReader sampleRelatedInputs, TextReader sampleUnrelatedInput,
                                ILogger log, ExecutionContext context)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Console.WriteLine("Get the function trigger msg:");
            Console.WriteLine(JsonConvert.SerializeObject(functionTriggerMsg));
            Console.WriteLine("Get the sample related inputs:");
            Console.WriteLine(sampleRelatedInputs.ReadToEnd());
            Console.WriteLine("Get the sample unrelated inputs:");
            Console.WriteLine(sampleUnrelatedInput.ReadToEnd());
            log.LogInformation($"C# Queue trigger function processed: {functionTriggerMsg}");
            return "1";
        }
    }
}
