using UnityEngine;
using Zenject;

namespace Game
{
    public abstract class ItemTrigger : MonoBehaviour
    {
        private protected Audio _audio;

        [Inject]
        public void Constructor(Audio audio)
        {
            _audio = audio;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IPoints>(out IPoints points))
            {
                Execute(points);
            }
        }

        public virtual void Execute(IPoints points) { }
    }
}