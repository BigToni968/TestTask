using UnityEngine;

namespace Game
{
    public interface IPathPoint
    {
        public Transform Transform { get; }
    }

    public class PathPoint : MonoBehaviour, IPathPoint
    {
        public Transform Transform => transform;

#if UNITY_EDITOR
        [SerializeField] private Color _color;
        [SerializeField] private float _radius;

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
#endif
    }
}