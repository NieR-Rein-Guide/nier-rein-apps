using Grpc.Core;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

namespace NierReincarnation.Core.Adam.Framework.Network;

public static class ResponseContextExtensions
{
    public static CommonResponse GetCommonResponse(this ResponseContext responseContext)
    {
        if (responseContext.Items.TryGetValue(nameof(CommonResponse), out var response) && response != null)
        {
            return (CommonResponse)response;
        }

        var commonResponse = responseContext.Items[nameof(CommonResponse)] = responseContext.GetTrailers().GetCommonResponse();
        return (CommonResponse)commonResponse;
    }

    public static CommonResponse GetCommonResponse(this Metadata trailerMetadata)
    {
        CommonResponse commonResponse = new();
        if (trailerMetadata == null)
            return commonResponse;

        foreach (var entry in trailerMetadata)
        {
            switch (entry.Key)
            {
                case "x-apb-response-datetime":
                    long.TryParse(entry.Value, out commonResponse.ResponseDatetime);
                    break;

                case "x-apb-debug-stack-trace":
                    commonResponse.DebugStackTrace = entry.Value;
                    break;

                case "x-apb-update-user-data-names":
                    commonResponse.UpdateUserDataNames = entry.Value.Split(',') ?? Array.Empty<string>();
                    break;

                case "x-apb-token":
                    commonResponse.Token = entry.Value;
                    break;

                case "x-apb-achievement-ids":
                    commonResponse.AchievementIdList = entry.Value.Split(',').Select(int.Parse).ToArray() ?? Array.Empty<int>();
                    break;

                case "x-apb-app-version-status-type":
                    int.TryParse(entry.Value, out commonResponse.AppVersionStatusType);
                    break;

                case "x-apb-original-response-datetime":
                    long.TryParse(entry.Value, out commonResponse.OriginalResponseDatetime);
                    break;

                case "x-apb-message-text":
                    commonResponse.MessageText = entry.Value;
                    break;

                case "x-apb-screen-transition-type":
                    Enum.TryParse(entry.Value, true, out commonResponse.ScreenTransitionType);
                    break;

                case "x-apb-message-code":
                    commonResponse.MessageCode = entry.Value;
                    break;

                case "x-apb-message-datetime":
                    long.TryParse(entry.Value, out commonResponse.MaintenanceDateTime);
                    break;

                case "x-apb-message-text-id":
                    commonResponse.MessageTextId = entry.Value;
                    break;
            }
        }

        return commonResponse;
    }
}
