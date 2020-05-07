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
        // The name of the asset updated
        "assetName": "TestAsset"
    }

```
*/
//
//

using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

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
using advanced_vod_functions_v3.SharedLibs.amsv2;

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
            string accountName = System.Environment.GetEnvironmentVariable("AccountName");
            string resourceGroup = System.Environment.GetEnvironmentVariable("ResourceGroup");
            MediaServicesConfigWrapper amsconfig = new MediaServicesConfigWrapper();
            
            // Transform & Job
            string transformName = "abrTransform";
            string jobName = "job-" + Guid.NewGuid();

            // Asset & Url
            string remoteUrl = Convert.ToString(data.remoteUrl);
            string assetName = Convert.ToString(data.assetName);

            try
            {
                IAzureMediaServicesClient client = MediaServicesHelper.CreateMediaServicesClientAsync(amsconfig);

                // Encode from any HTTPs source URL - a new feature of the v3 API.
                JobInputHttp jobInput =
                    new JobInputHttp(files: new List<string>{ remoteUrl });

                JobOutput[] jobOutputs =
                {
                    new JobOutputAsset(assetName),
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
            }
            catch (ApiErrorException e)
            {
                log.LogError($"ERROR: AMS API call failed with error code: {e.Body.Error.Code} and message: {e.Body.Error.Message}");
                return new BadRequestObjectResult("AMS API call error: " + e.Message + "\nError Code: " + e.Body.Error.Code + "\nMessage: " + e.Body.Error.Message);
            }
            catch (Exception e)
            {
                log.LogError($"ERROR: Exception with message: {e.Message}");
                return new BadRequestObjectResult("Error: " + e.Message + " caused by " + e.StackTrace);
            }

            return (ActionResult)new OkObjectResult(new
            {
                assetName = assetName
            });
        }
    }
}
