using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionWIthMultipleBlobBlinding
{
    public class FunctionTriggerMsg
    {
        public string TnDEngineSampleRelatedInputs { get; set; }
        public string TnDEngineSampleUnrelatedInput { get; set; }
        public string Destination { get; set; }
    }
}
