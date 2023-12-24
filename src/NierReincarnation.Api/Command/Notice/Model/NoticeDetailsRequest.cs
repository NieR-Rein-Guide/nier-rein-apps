using NierReincarnation.Api.Model;

namespace NierReincarnation.Api.Command;

internal record NoticeDetailsRequest(CommonRequest CommonRequest, int InformationId);