using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _interactRange = 10;
    void Start()
    {
        _camera = Camera.main;
    }

    public void OnInteract(CallbackContext value)
    {
        if(value.started)
        {
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * _interactRange, Color.red, 1);

            if (Physics.Raycast(ray, out hit, _interactRange))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(_camera.transform.position, _camera.transform.forward * _interactRange);
    }
}
public interface IInteractable
{
    void Interact();
}
