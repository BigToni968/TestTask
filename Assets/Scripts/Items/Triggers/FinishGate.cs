using System.Collections;
using UnityEngine;

namespace Game
{
    public class FinishGate : ItemTrigger
    {
        [SerializeField] private WindowNotify _windowNotify;
        [SerializeField] private float _durationWindowNotify;

        private IEnumerator DelayShowWindow()
        {
            yield return new WaitForSeconds(_durationWindowNotify);
            _windowNotify.Message("Победа!");
        }

        public override void Execute(IPoints points)
        {
            base.Execute(points);
            StartCoroutine(DelayShowWindow());
        }
    }
}