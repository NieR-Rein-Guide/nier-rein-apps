namespace NierReincarnation.Api.Authentication;

public record AuthenticationUrlResult(bool Success, string Uuid = "", string Url = "");
