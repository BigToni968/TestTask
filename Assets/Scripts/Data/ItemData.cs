using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Data/Item")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private ItemModel _model;

        public ItemModel GetModel()
        {
            return _model.Clone() as ItemModel;
        }
    }
}