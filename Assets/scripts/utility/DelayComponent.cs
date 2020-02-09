using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace utils
{
    public class DelayComponent : MonoBehaviour
    {
        [SerializeField] private float _time;
        [SerializeField] private UnityEvent DelayEvent;

        public void Delay()
        {
            StartCoroutine(TimerOn(_time));
        }

        private IEnumerator TimerOn(float time)
        {
            yield return new WaitForSeconds(time);
            DelayEvent?.Invoke();
        }
    }
}