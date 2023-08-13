namespace NierReincarnation.Api.Authentication;

public record TransferUserResult(bool Success, long UserId = 0, string Signature = "");
