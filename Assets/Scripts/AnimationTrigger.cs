using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent TriggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEvent?.Invoke();
    }
}
