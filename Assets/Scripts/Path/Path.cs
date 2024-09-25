using UnityEngine;

namespace Game
{
    public interface IPath
    {
        public IPathPoint Next();
    }

    public class Path : MonoBehaviour, IPath
    {
        [SerializeField] private bool _findPoints;
        [SerializeField] private PathPoint[] _points;

        private int _index;

        private void OnValidate()
        {
            if (!_findPoints)
            {
                return;
            }

            _findPoints = false;
            IPathPoint[] points = GetComponentsInChildren<IPathPoint>();
            _points = new PathPoint[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                _points[i] = points[i] as PathPoint;
            }
        }

        public IPathPoint Next()
        {
            if (_index < _points.Length)
            {
                _index++;
                return _points[_index - 1];
            }

            return null;
        }
    }
}