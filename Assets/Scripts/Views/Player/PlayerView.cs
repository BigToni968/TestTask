using UnityEngine;

namespace Game
{
    public abstract class PlayerView : View, IPoints, IPointsCallback, IPathCollisionCallback
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        public event IPointsCallback.DelegatePoints OnPointsCallback;
        public event IPathCollisionCallback.DelegatePathCollision PathCollisionEnterCallback;
        public event IPointsCallback.DelegateTotalPoints OnTotalPointsCallback;

        public void Take(int points)
        {
            OnPointsCallback?.Invoke(points);
        }

        public int Total()
        {
            int result = 0;

            if (OnTotalPointsCallback != null)
            {
                result = OnTotalPointsCallback.Invoke();
            }

            return result;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent<PathCollisionEnter>(out PathCollisionEnter path))
            {
                Destroy(path);
                PathCollisionEnterCallback?.Invoke();
            }
        }
    }
}