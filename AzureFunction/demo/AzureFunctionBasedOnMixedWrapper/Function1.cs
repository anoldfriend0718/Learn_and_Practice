using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MixedWrapper;

namespace AzureFunctionBasedOnPInvoke
{
    public static class Function1
    {
        [FunctionName("BasicFunction")]
        [StorageAccount("AzureWebJobsStorage")]
        [return: Queue("{destination}")]
        public static string Run([QueueTrigger("tndengine-input")]FunctionInputMsg input,
                                    [Blob("tndengine-input/{name}", FileAccess.Read)] TextReader inputReader, ILogger log, ExecutionContext context)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var strInput = inputReader.ReadToEnd();
            var basicFunctionInput = JsonConvert.DeserializeObject<BasicFuntionInput>(strInput);
            var functionInput = basicFunctionInput.Input.ToString();
            var functionContext = basicFunctionInput.Context.ToString();

            using (Entity e = new Entity("The Wallman", 20, 35))
            {
                e.Move(5, -10);
                log.LogDebug($"{e.GetName()} has been moved.");
                log.LogDebug(e.GetXPosition() + " " + e.GetYPosition());
            }

            return "1";
        }
    }
}
