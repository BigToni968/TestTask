using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class Gate : ItemTrigger
    {
        [SerializeField] private Transform _leftDoor;
        [SerializeField] private Transform _rightDoor;
        [SerializeField] private int _pointMultiplier;
        [SerializeField] private float _durationAnim;
        [SerializeField] private float _anglesY;

        private Sequence _sequence;

        private void Start()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(_leftDoor.DOLocalRotate(new Vector3(_leftDoor.localEulerAngles.x, -_anglesY, _rightDoor.localEulerAngles.z), _durationAnim));
            _sequence.Join(_rightDoor.DOLocalRotate(new Vector3(_rightDoor.localEulerAngles.x, _anglesY, _rightDoor.localEulerAngles.z), _durationAnim));
            _sequence.Pause();
        }

        public override void Execute(IPoints points)
        {
            base.Execute(points);
            points.Take(points.Total() * _pointMultiplier);
            _sequence?.Play();
        }

        private void OnDestroy()
        {
            _sequence?.Kill();
        }
    }
}