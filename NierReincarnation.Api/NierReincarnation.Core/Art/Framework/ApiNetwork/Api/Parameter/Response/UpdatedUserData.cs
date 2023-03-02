using System.Collections.Generic;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response
{
    // Art.Framework.ApiNetwork.Api.Parameter.Response.UpdatedUserData
    class UpdatedUserData
    {
        public Dictionary<string, UpdatedUserDataList> updateUserDataMap; // 0x10
        public Dictionary<string, DeletedUserDataList> deleteUserDataMap; // 0x18

        public UpdatedUserData()
        {
            updateUserDataMap = new Dictionary<string, UpdatedUserDataList>();
            deleteUserDataMap = new Dictionary<string, DeletedUserDataList>();
        }
    }
}
