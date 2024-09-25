using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class FlagsLine : ItemTrigger
    {
        [SerializeField] private Transform _leftFlags;
        [SerializeField] private Transform _rightFlags;
        [SerializeField] private float _durationAnim;
        [SerializeField] private float _anglesZ;

        private Sequence _sequence;

        private void Start()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(_leftFlags.DOLocalRotate(new Vector3(_leftFlags.localEulerAngles.x, _leftFlags.localEulerAngles.y, _anglesZ), _durationAnim));
            _sequence.Join(_rightFlags.DOLocalRotate(new Vector3(_rightFlags.localEulerAngles.x, _rightFlags.localEulerAngles.y, _anglesZ), _durationAnim));
            _sequence.Pause();
        }

        public override void Execute(IPoints points)
        {
            base.Execute(points);
            _sequence?.Play();
        }

        private void OnDestroy()
        {
            _sequence?.Kill();
        }
    }
}