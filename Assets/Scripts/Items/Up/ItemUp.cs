using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class ItemUp : ItemTrigger
    {
        [SerializeField] private ItemData _data;
        [SerializeField] private ItemModel _model;
        [SerializeField] private float _durationAnim;
        [SerializeField] private float _height;

        private Sequence _sequence;

        private void Start()
        {
            _model = _data.GetModel();
            DOTween.SetTweensCapacity(5000, 100);
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOLocalMoveY(transform.localPosition.y - _height, _durationAnim));
            _sequence.SetLoops(-1, LoopType.Yoyo);
        }

        public override void Execute(IPoints points)
        {
            base.Execute(points);
            if (_model.RewardPoints > 0)
            {
                _audio.PlayMoney();
            }

            if (_model.RewardPoints < 0)
            {
                _audio.PlayBottle();
            }

            points.Take(_model.IsRandom ? _model.RandomPoints() : _model.RewardPoints);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _sequence?.Kill();
        }
    }
}