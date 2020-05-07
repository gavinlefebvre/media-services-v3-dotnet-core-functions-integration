//
// Azure Media Services REST API v3 Functions
//
// CopyUrlToStorage - This function downloads a remote file and submits it to a job.
//
/*
```c#
Input:
    {
        // [Required] The name of the asset
        "assetName": "TestAsset",

        // [Required] Url of the file to copy
        "remoteUrl":  "https://example.com/vid.mp4"
    }
Output:
    {
        // The name of the asset created
        "assetName": "TestAsset",

        // The identifier of the asset created
        "assetId": "nb:cid:UUID:68adb036-43b7-45e6-81bd-8cf32013c810",

        // The name of the destination container name for the asset created
        "destinationContainer": "destinationContainer": "asset-4a5f429c-686c-4f6f-ae86-4078a4e6139e"
    }

```
*/
//
//

using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using advanced_vod_functions_v3.SharedLibs;


namespace advanced_vod_functions_v3
{
    public static class CopyUrlToStorage
    {
        [FunctionName("CopyUrlToStorage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"AMS v3 Function - CopyUrlToStorage was triggered!");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            // Set up ENV variables
            accountName = System.Environment.GetEnvironmentVariable("AccountName");
            resourceGroup = System.Environment.GetEnvironmentVariable("ResourceGroup");
            // Transform & Job
            transformName = "abrTransform";
            jobName = "job-" + Guid();


            // Encode from any HTTPs source URL - a new feature of the v3 API.  
            JobInputHttp jobInput =
                new JobInputHttp(files: new[] { data.remoteUrl });

            JobOutput[] jobOutputs =
            {
                new JobOutputAsset(data.assetName),
            };

            // In this function, we are ensuring that the job name is unique.
            Job job = await client.Jobs.CreateAsync(
                resourceGroup,
                accountName,
                transformName,
                jobName,
                new Job
                {
                    Input = jobInput,
                    Outputs = jobOutputs,
                });

            return (ActionResult)new OkObjectResult(new
            {
                job.name
            });
        }
    }
}
