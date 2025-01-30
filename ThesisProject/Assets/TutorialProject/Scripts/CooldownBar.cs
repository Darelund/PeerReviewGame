using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] private Image CooldownImage;
    [SerializeField] private Gradient colorGradient;
    private float cooldownTimer = 0;
    private float cooldownTime;
    private bool isCooldown = false;


    private void Start()
    {
        CooldownImage = GetComponentInChildren<Image>();
        CooldownImage.color = colorGradient.Evaluate(CooldownImage.fillAmount);
    }
    private void Update()
    {
        if(isCooldown)
        {
            cooldownTimer += Time.deltaTime;
            UpdateCooldownBar(cooldownTimer / cooldownTime);
        }
    }
    public void StartCooldown(float cooldownTime)
    {
        isCooldown = true;
        this.cooldownTime = cooldownTime;
    }
    public void StopCooldown()
    {
        isCooldown = false;
        cooldownTimer = 0;
        CooldownImage.fillAmount = 0;
    }
    public void UpdateCooldownBar(float healthLeft)
    {
        CooldownImage.fillAmount = healthLeft;
        CooldownImage.color = colorGradient.Evaluate(healthLeft);
    }
}
