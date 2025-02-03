using UnityEngine;

public class AnimationArmorStand : MonoBehaviour, IInteractable
{
    [SerializeField] private Animation _animation;
    private void Start()
    {
        _animation = GetComponent<Animation>();
    }
    public void Interact()
    {
       if(!_animation.isPlaying)
        {
            _animation.Play();
          // _animation.
         // _animation.
        }
    }
}
