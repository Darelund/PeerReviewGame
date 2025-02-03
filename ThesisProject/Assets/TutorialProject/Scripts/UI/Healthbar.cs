using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Image healthbarImage;
    [SerializeField] private Gradient colorGradient;

    private void Start()
    {
        _camera = Camera.main;
        healthbarImage = GetComponentInChildren<Image>();
        healthbarImage.color = colorGradient.Evaluate(healthbarImage.fillAmount);
    }

    private void Update()
    {
        healthbarImage.transform.LookAt(_camera.transform, Vector3.up);
    }


    public void UpdateHealthBar(float healthLeft)
    {
        healthbarImage.fillAmount = healthLeft;
        healthbarImage.color = colorGradient.Evaluate(healthLeft);
    }
}
