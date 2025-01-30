using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioClip _stepSound;
    [SerializeField] private AudioClip[] _idleSounds;
    private int randomIdleAudio;
    private float _idleAmount = 10;
    [SerializeField]private float _idleTimer = 0;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _stepSound = SoundBank.Instance.FootSteps;
        _audioSource.clip = _stepSound;
    }

    private void Update()
    {
        _idleTimer += Time.deltaTime;
        if(_idleTimer > _idleAmount)
        {
            //if(GetComponent<Animator>().("IsSwinging"))
            //{
            //    _idleTimer = 0;
            //    return;
            //}
            //if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Swing"))
            //{
            //    _idleTimer = 0;
            //    return;
            //}
            if(_audioSource.clip != _idleSounds[randomIdleAudio])
            _audioSource.clip = _idleSounds[randomIdleAudio];

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
    }
    public void OnAttack(CallbackContext value)
    {
        if (value.started && GetComponent<PlayerSwingAnimation>().canAttack)
        {
            _idleTimer = 0;
            randomIdleAudio = Random.Range(0, _idleSounds.Length);
        }
    }
    public void OnMovement(CallbackContext value)
    {
        if (value.performed)
        {
            if (_audioSource.clip != _stepSound)
                _audioSource.clip = _stepSound;

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            // _audioSource.time = 0;
        }
        else if (value.canceled)
        {
            _audioSource.Pause();
        }
        _idleTimer = 0;
        randomIdleAudio = Random.Range(0, _idleSounds.Length);
        //I am to lazy to add it, but 2 challenge yourself
        //You could just add a sound after x seconds
        //Everytime you walk you reset a number to 0
        //Then you check in update if this number is more than 5
        //If it is then play a hum/whistle sound
    }
}
