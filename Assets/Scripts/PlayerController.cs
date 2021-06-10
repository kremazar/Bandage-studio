using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.81f;

    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    public float speed = 5f;

    //stamina
    public float Stamina = 100.0f;
    public float MaxStamina = 100.0f;
    private float StaminaRegenTimer = 0.0f;
    private const float StaminaDecreasePerFrame = 50.0f;
    private const float StaminaIncreasePerFrame = 25.0f;
    private const float StaminaTimeToRegen = 3.0f;

    void Start() {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning){
            if(Stamina > 0) {
                speed = 10f;
            }
            Stamina = Mathf.Clamp(Stamina - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            StaminaRegenTimer = 0.0f;
        }
        else if (Stamina < MaxStamina){
            if (StaminaRegenTimer >= StaminaTimeToRegen) {
                Stamina = Mathf.Clamp(Stamina + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            }
            else {
                StaminaRegenTimer += Time.deltaTime;
            }
        }
        if(!isRunning) {
            if(Stamina > 20) {
                speed = 5f;
            } else {
                speed = 3f;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
