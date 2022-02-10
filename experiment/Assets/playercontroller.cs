using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private float sprintspeed = 1.3f;
    [SerializeField] private float mouse_sensitivity = 50f;
    [SerializeField] private float minCameraview = -70f, maxCameraview = 80f;


    private CharacterController CharacterController;
    private Camera _camera;
    private float Xrotation = 0f;
    private Vector3 playerVelocity;

    



    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

        _camera = Camera.main;

        if (CharacterController == null)
            Debug.Log("No Character Controller attached to Player");

        Cursor.lockState = CursorLockMode.Locked;
    }




    // Update is called once per frame
    void Update()
    {
        playermovement();
        cameramovement();

        

    }

    private void FixedUpdate()
    {
        if (CharacterController.isGrounded)
        {
            playerVelocity.y = 0f;
        }
        else
        {
            playerVelocity.y += -9.18f * Time.deltaTime;
            CharacterController.Move(playerVelocity * Time.deltaTime);
        }
    }


    private void playermovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical + transform.right * horizontal;

        bool sprint = Input.GetKey(KeyCode.LeftShift);
        bool sprinting = sprint;

        float fastspeed = speed;
        if (sprinting)
        {
            fastspeed *= sprintspeed;
        }

        CharacterController.Move(movement * Time.deltaTime * fastspeed);
    }


    private void cameramovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, minCameraview, maxCameraview);

        Camera.main.transform.localRotation = Quaternion.Euler(Xrotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX * 1.25f);
    }


    
     
}
