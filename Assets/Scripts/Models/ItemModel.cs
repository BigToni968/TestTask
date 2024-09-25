using Random = UnityEngine.Random;
using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class ItemModel : ICloneable
    {
        public int RewardPoints;
        public bool IsRandom;
        public Vector2Int RewardRandomPoints;

        public int RandomPoints()
        {
            return Random.Range(RewardRandomPoints.x, RewardRandomPoints.y);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}