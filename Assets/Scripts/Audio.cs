using UnityEngine;

namespace Game
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _money;
        [SerializeField] private AudioClip _bottle;

        public void PlayMoney()
        {
            _source.clip = _money;
            _source.Play();
        }

        public void PlayBottle()
        {
            _source.clip = _bottle;
            _source.Play();
        }
    }
}