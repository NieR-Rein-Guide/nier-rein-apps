namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

public class UpdatedUserData
{
    public Dictionary<string, UpdatedUserDataList> UpdateUserDataMap = new();
    public Dictionary<string, DeletedUserDataList> DeleteUserDataMap = new();
}
