using UnityEngine;
using Cinemachine;
using DG.Tweening;
using Game.Data;
using Zenject;

namespace Game
{
    public class Player : MonoBehaviour, IPointsCallback
    {
        [SerializeField] private PlayerDataUpgrades _upgrades;
        [SerializeField] private FloatingJoystick _input;
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private WindowNotify _notify;
        [SerializeField] private PlayerModel _model;

        private PlayerView _view;
        private IPath _path;
        private IPathPoint _pathPoint;
        private bool _upgradeNext;

        public event IPointsCallback.DelegatePoints OnPointsCallback;
        public event IPointsCallback.DelegateTotalPoints OnTotalPointsCallback;

        [Inject]
        public void Constructor(IPath path)
        {
            _path = path;
        }

        private void Start()
        {
            Upgrade(_view);
        }

        private void Upgrade(PlayerView view = null)
        {
            PlayerModel model = _upgrades.GetData(view);
            _upgradeNext = _upgrades.IsNext(view);

            if (!_upgradeNext)
            {
                return;
            }

            if (view != null)
            {
                model.TotalPoints = _model.TotalPoints;
                view.Hide();
                _camera.LookAt = _camera.Follow = null;
                view.OnPointsCallback -= TakePoints;
                view.PathCollisionEnterCallback -= TryRotate;
                view.OnTotalPointsCallback -= TotalPoints;
                Destroy(view.gameObject);
            }

            _model = model;
            _view = Instantiate(_model.PrefabView as PlayerView, transform);
            _view.OnPointsCallback += TakePoints;
            _view.PathCollisionEnterCallback += TryRotate;
            _view.OnTotalPointsCallback += TotalPoints;
            _camera.LookAt = _camera.Follow = _view.transform;
        }

        private void TryUpgrade()
        {
            if (_upgradeNext && _model.TotalPoints >= _model.MaxPoints)
            {
                Upgrade(_view);
            }
        }

        private void Move()
        {
            if (_view != null && _pathPoint != null && Vector3.Distance(_view.transform.position, _pathPoint.Transform.position) > _model.ClampX)
            {
                //Forward
                transform.parent.Translate(Vector3.forward * Time.deltaTime * _model.SpeedMoveForward, Space.Self);

                //Horizontal
                Vector3 newPosition = Vector3.right * _input.Horizontal * Time.deltaTime * _model.SpeedMoveX;
                _view.transform.Translate(newPosition, Space.Self);
                newPosition = _view.transform.localPosition;
                newPosition.x = Mathf.Clamp(newPosition.x, -_model.ClampX, _model.ClampX);
                _view.transform.localPosition = newPosition;
            }
        }

        private void TakePoints(int points)
        {
            _model.TotalPoints += points;
            _model.TotalPoints = Mathf.Clamp(_model.TotalPoints, -1, int.MaxValue);
            OnPointsCallback?.Invoke(_model.TotalPoints);
        }

        private int TotalPoints()
        {
            return _model.TotalPoints;
        }

        private void Rotate()
        {
            if (_view == null || _pathPoint == null)
            {
                return;
            }

            Vector3 directionToTarget = _pathPoint.Transform.position - transform.parent.position;
            directionToTarget.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            Vector3 rotationEuler = lookRotation.eulerAngles;
            rotationEuler.y = rotationEuler.y > 45f ? rotationEuler.y + 90f - rotationEuler.y : 0f;
            transform.parent.DORotate(new Vector3(0f, rotationEuler.y, 0f), _model.DurationRotate);
            _view.transform.DOLocalMoveX(0, _model.DurationAlignment);
        }

        private void TryRotate()
        {
            _pathPoint = _path.Next();
            Rotate();
        }

        private void Lose()
        {
            if (_model.TotalPoints < 0)
            {
                _notify.Message("Проигрыш!");
                _view = null;
            }
        }

        private void Update()
        {
            Move();
            TryUpgrade();
            Lose();
        }
    }
}