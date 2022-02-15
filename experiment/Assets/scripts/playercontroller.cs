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

    Vector3 velocity;
    public float gravity = -20.81f;

    [SerializeField] public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    bool isGrounded;





    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

        _camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playermovement();
        cameramovement();

    }

    private void playermovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * z + transform.right * x;

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

    private void gravity()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        CharacterController.Move(velocity * Time.deltaTime):
    }
    
     
}
