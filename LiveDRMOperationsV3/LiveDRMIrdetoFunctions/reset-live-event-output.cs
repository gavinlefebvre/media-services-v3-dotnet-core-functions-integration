//
// Azure Media Services REST API v3 Functions
//
// reset-live-event-output - This function resets a new live event and output (to be used with Irdeto)
// keys are reused when possible, streaming policies are reused
// locator GUID is new (so output URLs will change)
//
// if live event is stopped, then it will still "reset" the live output (recreate a new one)
/*
```c#
Input :
{
    "liveEventName": "CH1",
    "deleteAsset" : false, // optional, default is True - if asset is not deleted then we cannot reuse the keys for the new asset. New keys will be used for the new asset.
    "azureRegion": "euwe" or "we" or "euno" or "no"// optional. If this value is set, then the AMS account name and resource group are appended with this value. Resource name is not changed if "ResourceGroupFinalName" in app settings is to a value non empty. This feature is useful if you want to manage several AMS account in different regions. Note: the service principal must work with all this accounts
    "archiveWindowLength" : 20  // value in minutes, optional. Default is 10 (minutes)
}



Output:
{
  "success": true,
  "operationsVersion": "1.0.0.5",
  "liveEvents": [
    {
      "liveEventName": "CH1",
      "resourceState": "Running",
      "vanityUrl": true,
      "amsAccountName": "customerssrlivedeveuwe",
      "region": "West Europe",
      "resourceGroup": "GD-INIT-DISTLSV-dev-euwe",
      "lowLatency": false,
      "id": "customerssrlivedeveuwe:CH1",
      "input": [
        {
          "protocol": "FragmentedMP4",
          "url": "http://CH1-customerssrlivedeveuwe-euwe.channel.media.azure.net/838afbbac2514fafa2eaed76d8a3cc74/ingest.isml"
        }
      ],
      "inputACL": [
        "192.168.0.0/24",
        "86.246.149.14/0"
      ],
      "preview": [
        {
          "protocol": "FragmentedMP4",
          "url": "https://CH1-customerssrlivedeveuwe.preview-euwe.channel.media.azure.net/90083bd1-bed3-4019-9d54-b70e314ac9c8/preview.ism/manifest"
        }
      ],
      "previewACL": [
        "192.168.0.0/24",
        "86.246.149.14/0"
      ],
      "liveOutputs": [
        {
          "liveOutputName": "output-179744a9-3f6f",
          "archiveWindowLength": 120,
          "assetName": "asset-179744a9-3f6f",
          "assetStorageAccountName": "rsilsvdeveuwe",
          "resourceState": "Running",
          "streamingLocators": [
            {
              "streamingLocatorName": "locator-179744a9-3f6f",
              "streamingPolicyName": "CH1-321870db-de01",
              "cencKeyId": "58420ba1-da30-4756-b50c-fcd72a9645b7",
              "cbcsKeyId": "ced687fd-c34b-433e-bca7-346a1d7af9f5",
              "drm": [
                {
                  "type": "FairPlay",
                  "licenseUrl": "skd://rng.live.ott.irdeto.com/licenseServer/streaming/v1/CUSTOMER/getckc?ContentId=CH1&KeyId=ced687fd-c34b-433e-bca7-346a1d7af9f5",
                  "protocols": [
                    "DashCmaf",
                    "HlsCmaf",
                    "HlsTs"
                  ]
                },
                {
                  "type": "PlayReady",
                  "licenseUrl": "https://rng.live.ott.irdeto.com/licenseServer/playready/v1/CUSTOMER/license?ContentId=CH1",
                  "protocols": [
                    "DashCmaf",
                    "DashCsf"
                  ]
                },
                {
                  "type": "Widevine",
                  "licenseUrl": "https://rng.live.ott.irdeto.com/licenseServer/widevine/v1/CUSTOMER/license&ContentId=CH1",
                  "protocols": [
                    "DashCmaf",
                    "DashCsf"
                  ]
                }
              ],
              "urls": [
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/a2fa92c4-77dc-4305-a20e-21c8ad20c8c0/CH1.ism/manifest(encryption=cenc)",
                  "protocol": "SmoothStreaming"
                },
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/a2fa92c4-77dc-4305-a20e-21c8ad20c8c0/CH1.ism/manifest(format=mpd-time-csf,encryption=cenc)",
                  "protocol": "DashCsf"
                },
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/a2fa92c4-77dc-4305-a20e-21c8ad20c8c0/CH1.ism/manifest(format=mpd-time-cmaf,encryption=cenc)",
                  "protocol": "DashCmaf"
                },
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/a2fa92c4-77dc-4305-a20e-21c8ad20c8c0/CH1.ism/manifest(format=m3u8-cmaf,encryption=cenc)",
                  "protocol": "HlsCmaf"
                },
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/a2fa92c4-77dc-4305-a20e-21c8ad20c8c0/CH1.ism/manifest(format=m3u8-aapl,encryption=cenc)",
                  "protocol": "HlsTs"
                }
              ]
            },
            {
              "streamingLocatorName": "locator-92259edd-db65",
              "streamingPolicyName": "Predefined_ClearStreamingOnly",
              "cencKeyId": null,
              "cbcsKeyId": null,
              "drm": [],
              "urls": [
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/3405a404-268b-4d15-ac15-8c8779e555ca/CH1.ism/manifest",
                  "protocol": "SmoothStreaming"
                },
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/3405a404-268b-4d15-ac15-8c8779e555ca/CH1.ism/manifest(format=mpd-time-csf)",
                  "protocol": "DashCsf"
                },
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/3405a404-268b-4d15-ac15-8c8779e555ca/CH1.ism/manifest(format=mpd-time-cmaf)",
                  "protocol": "DashCmaf"
                },
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/3405a404-268b-4d15-ac15-8c8779e555ca/CH1.ism/manifest(format=m3u8-cmaf)",
                  "protocol": "HlsCmaf"
                },
                {
                  "url": "https://customerssrlsvdeveuwe-customerssrlivedeveuwe-euwe.streaming.media.azure.net/3405a404-268b-4d15-ac15-8c8779e555ca/CH1.ism/manifest(format=m3u8-aapl)",
                  "protocol": "HlsTs"
                }
              ]
            }
          ]
        }
      ]
    }
  ]
}

```
*/
//
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LiveDrmOperationsV3.Helpers;
using LiveDrmOperationsV3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LiveDrmOperationsV3
{
    public static class ResetChannel
    {
        private const string labelCenc = "cencDefaultKey";
        private const string labelCbcs = "cbcsDefaultKey";
        private const string assetprefix = "nb:cid:UUID:";

        // This version registers keys in irdeto backend. For FairPlay and rpv3

        [FunctionName("reset-live-event-output")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            ConfigWrapper config = null;
            try
            {
                config = new ConfigWrapper(new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddEnvironmentVariables()
                        .Build(),
                        (string)data.azureRegion
                );
            }
            catch (Exception ex)
            {
                return IrdetoHelpers.ReturnErrorException(log, ex);
            }

            log.LogInformation("config loaded.");
            log.LogInformation("connecting to AMS account : " + config.AccountName);

            var liveEventName = (string)data.liveEventName;
            if (liveEventName == null)
                return IrdetoHelpers.ReturnErrorException(log, "Error - please pass liveEventName in the JSON");

            // default settings
            var eventInfoFromCosmos = new LiveEventSettingsInfo
            {
                LiveEventName = liveEventName
            };

            // Load config from Cosmos
            try
            {
                var setting = await CosmosHelpers.ReadSettingsDocument(liveEventName);
                eventInfoFromCosmos = setting ?? eventInfoFromCosmos;

                if (setting == null) log.LogWarning("Settings not read from Cosmos.");
            }
            catch (Exception ex)
            {
                return IrdetoHelpers.ReturnErrorException(log, ex);
            }


            // init default

            var deleteAsset = true;
            if (data.deleteAsset != null) deleteAsset = (bool)data.deleteAsset;

            var uniqueness = Guid.NewGuid().ToString().Substring(0, 13);
            var manifestName = liveEventName.ToLower();


            var client = await MediaServicesHelpers.CreateMediaServicesClientAsync(config);
            // Set the polling interval for long running operations to 2 seconds.
            // The default value is 30 seconds for the .NET client SDK
            client.LongRunningOperationRetryTimeout = 2;

            Asset asset = null;
            LiveEvent liveEvent = null;
            LiveOutput liveOutput = null;
            Task<LiveOutput> taskLiveOutputCreation = null;

            var streamingLocatorsPolicies = new Dictionary<string, string>(); // locator name, policy name 
            string storageAccountName = null;

            Task taskReset = null;

            if (data.archiveWindowLength != null)
                eventInfoFromCosmos.ArchiveWindowLength = (int)data.archiveWindowLength;

            /*
            string cenckeyId = null;
            string cenccontentKey = null;
            string cbcskeyId = null;
            string cbcscontentKey = null;
            */
            var cencKey = new StreamingLocatorContentKey();
            var cbcsKey = new StreamingLocatorContentKey();

            bool createKeys = true;


            try
            {
                // let's check that the channel exists
                liveEvent = await client.LiveEvents.GetAsync(config.ResourceGroup, config.AccountName, liveEventName);
                if (liveEvent == null)
                    return IrdetoHelpers.ReturnErrorException(log, "Error : live event does not exist !");

                if (liveEvent.ResourceState != LiveEventResourceState.Running && liveEvent.ResourceState != LiveEventResourceState.Stopped)
                    return IrdetoHelpers.ReturnErrorException(log, "Error : live event should be in Running or Stopped state !");

                // get live output(s) - it should be one
                var myLiveOutputs = client.LiveOutputs.List(config.ResourceGroup, config.AccountName, liveEventName);


                // get the names of the streaming policies. If not possible, recreate it
                if (myLiveOutputs.FirstOrDefault() != null)
                {
                    asset = client.Assets.Get(config.ResourceGroup, config.AccountName,
                        myLiveOutputs.First().AssetName);

                    var streamingLocatorsNames = client.Assets.ListStreamingLocators(config.ResourceGroup, config.AccountName, asset.Name).StreamingLocators.Select(l => l.Name);
                    foreach (var locatorName in streamingLocatorsNames)
                    {
                        var locator =
                            client.StreamingLocators.Get(config.ResourceGroup, config.AccountName, locatorName);
                        if (locator != null)
                        {
                            streamingLocatorsPolicies.Add(locatorName, locator.StreamingPolicyName);
                            if (locator.StreamingPolicyName != PredefinedStreamingPolicy.ClearStreamingOnly) // let's backup the keys to reuse them
                            {
                                var keys = client.StreamingLocators.ListContentKeys(config.ResourceGroup, config.AccountName, locatorName).ContentKeys;
                                cencKey = keys.Where(k => k.LabelReferenceInStreamingPolicy == IrdetoHelpers.labelCenc).FirstOrDefault();
                                cbcsKey = keys.Where(k => k.LabelReferenceInStreamingPolicy == IrdetoHelpers.labelCbcs).FirstOrDefault();
                                if (deleteAsset) createKeys = false; // we can reuse the keys only if the previous asset is deleted
                            }
                        }
                    }
                }

                if (streamingLocatorsPolicies.Count == 0) // no way to get the streaming policy, let's create a new one
                {
                    log.LogInformation("Creating streaming policy.");
                    var streamingPolicy =
                        await IrdetoHelpers.CreateStreamingPolicyIrdeto(liveEventName, config, client);
                    streamingLocatorsPolicies.Add("", streamingPolicy.Name);
                }

                // let's purge all live output for now
                foreach (var p in myLiveOutputs)
                {
                    var assetName = p.AssetName;

                    var thisAsset = client.Assets.Get(config.ResourceGroup, config.AccountName, p.AssetName);
                    if (thisAsset != null)
                        storageAccountName =
                            thisAsset
                                .StorageAccountName; // let's backup storage account name to create the new asset here
                    log.LogInformation("deleting live output : " + p.Name);
                    await client.LiveOutputs.DeleteAsync(config.ResourceGroup, config.AccountName, liveEvent.Name,
                        p.Name);
                    if (deleteAsset)
                    {
                        log.LogInformation("deleting asset : " + assetName);
                        client.Assets.DeleteAsync(config.ResourceGroup, config.AccountName, assetName);
                    }
                }

                if (liveEvent.ResourceState == LiveEventResourceState.Running)
                {
                    log.LogInformation("reseting live event : " + liveEvent.Name);
                    taskReset = client.LiveEvents.ResetAsync(config.ResourceGroup, config.AccountName, liveEvent.Name);
                }
                else
                {
                    log.LogInformation("Skipping the reset of live event " + liveEvent.Name + " as it is stopped.");
                }
            }
            catch (Exception ex)
            {
                return IrdetoHelpers.ReturnErrorException(log, ex);
            }


            // LIVE OUTPUT CREATION
            log.LogInformation("Live output creation...");

            try
            {
                log.LogInformation("Asset creation...");
                asset = await client.Assets.CreateOrUpdateAsync(config.ResourceGroup, config.AccountName,
                    "asset-" + uniqueness, new Asset(storageAccountName: storageAccountName, description: null));

                Hls hlsParam = null;
                liveOutput = new LiveOutput(asset.Name, TimeSpan.FromMinutes(eventInfoFromCosmos.ArchiveWindowLength),
                    null, "output-" + uniqueness, null, null, manifestName,
                    hlsParam); //we put the streaming locator in description
                log.LogInformation("await task reset...");

                if (taskReset != null) await taskReset; // let's wait for the reset to complete

                log.LogInformation("create live output...");
                taskLiveOutputCreation = client.LiveOutputs.CreateAsync(config.ResourceGroup, config.AccountName,
                    liveEventName, liveOutput.Name, liveOutput);
            }
            catch (Exception ex)
            {
                return IrdetoHelpers.ReturnErrorException(log, ex, "live output creation error");
            }

            if (createKeys)
            {
                try
                {
                    log.LogInformation("Irdeto call...");

                    // CENC Key
                    cencKey.Id = Guid.NewGuid();
                    cencKey.Value = Convert.ToBase64String(IrdetoHelpers.GetRandomBuffer(16));
                    var cencIV = Convert.ToBase64String(cencKey.Id.ToByteArray());
                    var responsecenc = await IrdetoHelpers.CreateSoapEnvelopRegisterKeys(config.IrdetoSoapService,
                        liveEventName, config, cencKey.Id.ToString(), cencKey.Value, cencIV, false);
                    var contentcenc = await responsecenc.Content.ReadAsStringAsync();

                    if (responsecenc.StatusCode != HttpStatusCode.OK)
                        return IrdetoHelpers.ReturnErrorException(log, "Error Irdeto response cenc - " + contentcenc);

                    var cenckeyIdFromIrdeto = IrdetoHelpers.ReturnDataFromSoapResponse(contentcenc, "KeyId=");
                    var cenccontentKeyFromIrdeto = IrdetoHelpers.ReturnDataFromSoapResponse(contentcenc, "ContentKey=");

                    if (cencKey.Id.ToString() != cenckeyIdFromIrdeto || cencKey.Value != cenccontentKeyFromIrdeto)
                        return IrdetoHelpers.ReturnErrorException(log, "Error CENC not same key - " + contentcenc);

                    // CBCS Key
                    cbcsKey.Id = Guid.NewGuid();
                    cbcsKey.Value = Convert.ToBase64String(IrdetoHelpers.GetRandomBuffer(16));
                    var cbcsIV =
                        Convert.ToBase64String(
                            IrdetoHelpers.HexStringToByteArray(cbcsKey.Id.ToString().Replace("-", string.Empty)));
                    var responsecbcs = await IrdetoHelpers.CreateSoapEnvelopRegisterKeys(config.IrdetoSoapService,
                        liveEventName, config, cbcsKey.Id.ToString(), cbcsKey.Value, cbcsIV, true);
                    var contentcbcs = await responsecbcs.Content.ReadAsStringAsync();

                    if (responsecbcs.StatusCode != HttpStatusCode.OK)
                        return IrdetoHelpers.ReturnErrorException(log, "Error Irdeto response cbcs - " + contentcbcs);

                    var cbcskeyIdFromIrdeto = IrdetoHelpers.ReturnDataFromSoapResponse(contentcbcs, "KeyId=");
                    var cbcscontentKeyFromIrdeto = IrdetoHelpers.ReturnDataFromSoapResponse(contentcbcs, "ContentKey=");

                    if (cbcsKey.Id.ToString() != cbcskeyIdFromIrdeto || cbcsKey.Value != cbcscontentKeyFromIrdeto)
                        return IrdetoHelpers.ReturnErrorException(log, "Error CBCS not same key - " + contentcbcs);
                }
                catch (Exception ex)
                {
                    return IrdetoHelpers.ReturnErrorException(log, ex, "Irdeto response error");
                }
            }



            try
            {
                // streaming locator(s) creation
                log.LogInformation("Locator creation...");

                foreach (var entryLocPol in streamingLocatorsPolicies)
                {
                    string streamingLocatorName;

                    if (entryLocPol.Value == PredefinedStreamingPolicy.ClearStreamingOnly)
                    {
                        var uniqueness2 = Guid.NewGuid().ToString().Substring(0, 13);
                        streamingLocatorName = "locator-" + uniqueness2; // another uniqueness
                        log.LogInformation("creating clear locator : " + streamingLocatorName);
                        var locator =
                            await IrdetoHelpers.CreateClearLocator(config, streamingLocatorName, client, asset);
                    }
                    else // DRM content
                    {
                        streamingLocatorName = "locator-" + uniqueness; // sae uniqueness that asset or output
                        log.LogInformation("creating DRM locator : " + streamingLocatorName);

                        if (createKeys)
                        {
                            log.LogInformation("using new keys.");

                            var locator = await IrdetoHelpers.SetupDRMAndCreateLocatorWithNewKeys(
                                config, entryLocPol.Value, streamingLocatorName, client, asset, cencKey.Id.ToString(), cencKey.Value, cbcsKey.Id.ToString(), cbcsKey.Value);

                        }
                        else // no need to create new keys, let's use the exiting one
                        {
                            log.LogInformation("using existing keys.");

                            var locator = await IrdetoHelpers.SetupDRMAndCreateLocatorWithExistingKeys(
                                config, entryLocPol.Value, streamingLocatorName, client, asset, cencKey, cbcsKey);

                        }
                    }

                    log.LogInformation("locator : " + streamingLocatorName);
                }

                await client.Assets.UpdateAsync(config.ResourceGroup, config.AccountName, asset.Name, asset);

                await taskLiveOutputCreation;
            }
            catch (Exception ex)
            {
                return IrdetoHelpers.ReturnErrorException(log, ex, "locator creation error");
            }


            // object to store the output of the function
            var generalOutputInfo = new GeneralOutputInfo();

            // let's build info for the live event and output
            try
            {
                generalOutputInfo = GenerateInfoHelpers.GenerateOutputInformation(config, client, new List<LiveEvent>
                {
                    liveEvent
                });
            }

            catch (Exception ex)
            {
                return IrdetoHelpers.ReturnErrorException(log, ex);
            }

            try
            {
                if (!await CosmosHelpers.CreateOrUpdateGeneralInfoDocument(generalOutputInfo.LiveEvents[0]))
                    log.LogWarning("Cosmos access not configured.");
            }
            catch (Exception ex)
            {
                return IrdetoHelpers.ReturnErrorException(log, ex);
            }

            return new OkObjectResult(
                JsonConvert.SerializeObject(generalOutputInfo, Formatting.Indented)
            );
        }
    }
}