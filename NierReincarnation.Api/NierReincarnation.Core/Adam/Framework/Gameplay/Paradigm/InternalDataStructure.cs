using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.Dark.Variable;

namespace NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;

public class InternalDataStructure : DataStructureBase
{
    public bool GetVariable<TVariable>(string name, out TVariable value) where TVariable : new()
    {
        if (typeof(TVariable) == typeof(StateUser))
        {
            value = (TVariable)(object)new StateUser
            {
                Id = PlayerPreference.Instance.ActivePlayer.UserId,
                Uuid = PlayerPreference.Instance.ActivePlayer.Uuid,
                Signature = PlayerPreference.Instance.ActivePlayer.Signature
            };
            return true;
        }

        value = new TVariable();
        return false;
    }
}
