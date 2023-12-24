using NierReincarnation.Api.Model;

namespace NierReincarnation.Api.Command;
internal record NoticeDetailsResponse(InformationType InformationType, string Title, string Body,
    long PublishStartDatetime, long? PostscriptDatetime, long ResponseDatetime = 0) : CommonResponse(ResponseDatetime);