using UnityEngine;
using UnityEngine.UI;

public class F_HealthBar : MonoBehaviour
{
    private Camera Camera; //a reference that will serve to obtain our main camera in the scene
    private Image healthBarImage; //a reference to our Image object
    public Gradient ColorGradient; //a Gradient which will be used to change the color of the image depending on the amount of health left.

    private void Start()
    {
        healthBarImage = GetComponent<Image>();
        Camera = Camera.main;   // finds the main camera in the scene
    }

    private void Update()
    {
        transform.LookAt(Camera.transform, Vector3.up);//rotates the health bar to always be facing the camera
    }
    public void UpdateHealthBar(float healthLeft)
    {
        healthBarImage.fillAmount = healthLeft; 
        healthBarImage.color = ColorGradient.Evaluate(healthBarImage.fillAmount); // changes the color using the color gradient depending on the images fill amount as a float)
    }    
}
