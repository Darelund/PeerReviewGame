using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public AudioClip FootSteps;

    private static SoundBank instance;
    public static SoundBank Instance => instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
