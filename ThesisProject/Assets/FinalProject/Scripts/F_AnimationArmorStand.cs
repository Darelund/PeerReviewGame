using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class F_AnimationArmorStand : MonoBehaviour,F_IInteractable
{
    public void Interact()
    {
        if (GetComponent<Animation>().isPlaying)
        {
            return;
        }
        GetComponent<Animation>().Play();
    }
}
