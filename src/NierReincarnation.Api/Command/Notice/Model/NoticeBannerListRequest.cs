using NierReincarnation.Api.Model;

namespace NierReincarnation.Api.Command;

internal record NoticeBannerListRequest(CommonRequest CommonRequest, int[] InformationTypeList, string IsIngame, int Limit, int Offset);
