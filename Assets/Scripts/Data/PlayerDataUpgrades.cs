using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Upgrade/PlayerUpgrades")]
    public class PlayerDataUpgrades : ScriptableObject
    {
        [SerializeField] private PlayerModel[] _datas;

        public PlayerModel GetData(View key = null)
        {
            if (key == null)
            {
                return _datas[0].Clone() as PlayerModel;
            }

            for (int i = 0; i < _datas.Length; i++)
            {
                if (_datas[i].PrefabView.GetType() == key.GetType() && i + 1 < _datas.Length)
                {
                    return _datas[i + 1].Clone() as PlayerModel;
                }
            }

            return null;
        }

        public bool IsNext(View key = null)
        {
            if (key == null && _datas.Length > 1)
            {
                return true;
            }

            for (int i = 0; i < _datas.Length; i++)
            {
                if (_datas[i].PrefabView.GetType() == key.GetType())
                {
                    return i + 1 < _datas.Length;
                }
            }

            return false;
        }
    }
}