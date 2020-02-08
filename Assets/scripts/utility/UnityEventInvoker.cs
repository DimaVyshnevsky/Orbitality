using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace utils
{
    public class UnityEventInvoker : MonoBehaviour
    {
        public UnityEvent StartEvent; 

        void Start()
        {
            StartEvent?.Invoke();
        }
    }
}

