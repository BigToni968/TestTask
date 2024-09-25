using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class WindowTutorial : View
    {
        [SerializeField] private Transform _finger;
        [SerializeField] private float _durationAnimation;
        [SerializeField] private float _width;

        private Sequence _sequence;

        private void Start()
        {
            Time.timeScale = 0f;
            _sequence = DOTween.Sequence();
            _sequence.Append(_finger.DOLocalMoveX(_finger.localPosition.x - _width, _durationAnimation)).SetUpdate(true);
            _sequence.Append(_finger.DOLocalMoveX(_finger.localPosition.x + _width, _durationAnimation)).SetUpdate(true);
            _sequence.SetLoops(-1, LoopType.Yoyo);
        }

        public override void Hide()
        {
            base.Hide();
            Time.timeScale = 1f;
            _sequence?.Kill();
        }
    }
}