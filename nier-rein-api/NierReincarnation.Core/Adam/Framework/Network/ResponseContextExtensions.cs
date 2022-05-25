using System;
using System.Linq;
using Grpc.Core;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    // Adam.Framework.Network.ResponseContextExtensions
    static class ResponseContextExtensions
    {
        public static CommonResponse GetCommonResponse(this ResponseContext responseContext)
        {
            if (responseContext.Items.TryGetValue("CommonResponse", out var response) && response != null)
                return (CommonResponse)response;

            var commonResponse = responseContext.Items["CommonResponse"] = responseContext.GetTrailers().GetCommonResponse();
            return (CommonResponse)commonResponse;
        }

        public static CommonResponse GetCommonResponse(this Metadata trailerMetadata)
        {
            var commonResponse = new CommonResponse();
            if (trailerMetadata == null)
                return commonResponse;

            foreach (var entry in trailerMetadata)
            {
                switch (entry.Key)
                {
                    case "x-apb-response-datetime":
                        if (!long.TryParse(entry.Value, out commonResponse.responseDatetime))
                            ; // LogWarning
                        break;

                    case "x-apb-debug-stack-trace":
                        commonResponse.debugStackTrace = entry.Value;
                        break;

                    case "x-apb-update-user-data-names":
                        commonResponse.updateUserDataNames = entry.Value.Split(',') ?? Array.Empty<string>();
                        break;

                    case "x-apb-token":
                        commonResponse.token = entry.Value;
                        break;

                    case "x-apb-achievement-ids":
                        commonResponse.achievementIdList = entry.Value.Split(',').Select(int.Parse).ToArray() ?? Array.Empty<int>();
                        break;

                    case "x-apb-app-version-status-type":
                        if (!int.TryParse(entry.Value, out commonResponse.appVersionStatusType))
                            ; // LogWarning
                        break;

                    case "x-apb-original-response-datetime":
                        if (!long.TryParse(entry.Value, out commonResponse.originalResponseDatetime))
                            ; // LogWarning
                        break;

                    case "x-apb-message-text":
                        commonResponse.messageText = entry.Value;
                        break;

                    case "x-apb-screen-transition-type":
                        if (!int.TryParse(entry.Value, out commonResponse.screenTransitionType))
                            ; // LogWarning
                        break;

                    case "x-apb-message-code":
                        commonResponse.messageCode = entry.Value;
                        break;

                    case "x-apb-message-datetime":
                        if (!long.TryParse(entry.Value, out commonResponse.maintenanceDateTime))
                            ; // LogWarning
                        break;

                    case "x-apb-message-text-id":
                        commonResponse.messageTextId = entry.Value;
                        break;
                }
            }

            return commonResponse;
        }
    }
}
