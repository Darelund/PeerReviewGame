using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private int mouseSensitivity = 30;
    public int MouseSensitivity
    {
        get => mouseSensitivity; 
        set
        {
            if(value < 0)
            {
                throw new System.Exception("Can't give mouse sensitivity a negative value!");
            }
            else
            {
                mouseSensitivity = value;
            }
        }
    }

    [SerializeField] private Transform firstPersonCamera;
    [SerializeField] private Transform thirdPersonCamera;
    [SerializeField] private Transform currentCamera;



    private float xRotation, yRotation;
    private Vector2 mouseInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentCamera = firstPersonCamera;
    }


    private void Update()
    {
        mouseInput *= mouseSensitivity * Time.deltaTime;

        yRotation += mouseInput.x;
        xRotation -= mouseInput.y;
        xRotation = Mathf.Clamp(xRotation, -30, 45);

        currentCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.rotation = Quaternion.Euler(0, yRotation, 0);


        //if (Input.GetKeyDown(KeyCode.C))
        //    SwitchCamera();
    }
    public void SwitchCamera()
    {
        if(currentCamera == thirdPersonCamera)
        {
            firstPersonCamera.gameObject.SetActive(true);
            thirdPersonCamera.gameObject.SetActive(false);
            currentCamera = firstPersonCamera;
        }
        else
        {
            firstPersonCamera.gameObject.SetActive(false);
            thirdPersonCamera.gameObject.SetActive(true);
            currentCamera = thirdPersonCamera;
        }
    }

    public void OnLook(CallbackContext value)
    {
        mouseInput = value.ReadValue<Vector2>();
    }
}
