using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private CharacterController _enemyAI;
    private playercontroller _playerScript;

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
        _enemyAI = GetComponent<CharacterController>();

        if (_enemyAI == null) Debug.LogError("Enemy Script is Null");

        if (_playerScript == null) Debug.LogError("Player Script is Null");

    }



    // Update is called once per frame
    void Update()
    {
        
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
