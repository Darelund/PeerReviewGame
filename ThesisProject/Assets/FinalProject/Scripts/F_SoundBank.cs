using Unity.VisualScripting;
using UnityEngine;

public class F_SoundBank : MonoBehaviour
{
    //Sound files
    public AudioClip stepAudio;

    //Singleton
    public static F_SoundBank Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
