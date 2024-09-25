using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class PlayerModel : ICloneable
    {
        [field: SerializeField] public View PrefabView { get; private set; }

        public float SpeedMoveForward;
        public float SpeedMoveX;
        public float DurationRotate;
        public float DurationAlignment;
        public int TotalPoints;
        public int MaxPoints;
        public float ClampX;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}