using UnityEngine;
using UnityEngine.Events;

public class UnityEventCaller : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;
    [SerializeField] private string _tag;
    private bool _used = false;
    [SerializeField] private bool _destroyAfterInvoke = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!_used && other.CompareTag(_tag))
        {
            _used = true;
            _event.Invoke();
            if (_destroyAfterInvoke)
            {
                Destroy(gameObject,0.1f);
            }
        }
        
    }
}
