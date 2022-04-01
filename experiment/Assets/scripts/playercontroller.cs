using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private float speed = 10f;
    private float sprintspeed = 1.3f;
    private float mouse_sensitivity = 400f;
    private float minCameraview = -70f, maxCameraview = 80f;

    private CharacterController CharacterController;
    private Camera _camera;
    private float Xrotation = 0f;
    private float baseFOV;
    private float sprintFOV = 1.3f;

    Vector3 velocity;
    public float gravity = -20.18f;
    public float jumpHeight = 3f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    bool isGrounded;





    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

        _camera = Camera.main;
        baseFOV = _camera.fieldOfView;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playermovement();
        cameramovement();
        _gravity();

    }

    private void playermovement()
    {
        // Input for basic movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * z + transform.right * x;

        // Input for sprinting mechanic
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        bool sprinting = sprint;
        float fastspeed = speed;
        if (sprinting)
        {
            fastspeed *= sprintspeed;
        }

        // Changes FOV while sprinting
        if (sprinting) { _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, baseFOV * sprintFOV, Time.deltaTime * 8f); }
        else { _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, baseFOV, Time.deltaTime * 8f); } 

        CharacterController.Move(movement * Time.deltaTime * fastspeed);


        // Input code for jumping mechanic
        bool _jump = Input.GetButton("Jump") && isGrounded;
        bool jumping = _jump;
        if (jumping)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -9.18f);
        }
    }


    private void cameramovement()
    {
        // Input code for basic camera movement
        float mouseX = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, minCameraview, maxCameraview);

        Camera.main.transform.localRotation = Quaternion.Euler(Xrotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX * 1.25f);

    }

    private void _gravity()
    {
        // Gravity check mechanic
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        CharacterController.Move(velocity * Time.deltaTime);
    }
    
     
}
