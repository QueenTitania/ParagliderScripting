using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public PlayerStamina playerStamina;

    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeight = 3f;

    public float gliderSpeed = 7f;
    public float gliderGravity = -4.5f;

    public GameObject gliderGeo;
    public GameObject wind;
    public AudioSource activateSFX;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    public float staminaRate = 0.1f;

    bool isGrounded;
    bool activateGlider;
    Vector3 velocity;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!activateGlider && Input.GetButtonDown("Jump") && !isGrounded)
        {
            activateGlider = true;
            activateSFX.Play();
        }

        if (isGrounded)
        {
            //Debug.Log("Ground");
            activateGlider = false;
            wind.SetActive(false);
        }

        if (activateGlider && playerStamina.stamina > 0)
        {
            ParagliderMovement();
        }
        else
            GroundMovement();

    }

    void ParagliderMovement()
    {
        
        playerStamina.LoseStamina(staminaRate);
        gliderGeo.SetActive(true);
        wind.SetActive(true);
        //Debug.Log("Stamina: " + playerStamina.stamina);
        //Debug.Log("Gliding");
        if (velocity.y < gliderGravity)
            velocity.y = gliderGravity;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * gliderSpeed * Time.deltaTime);
        velocity.y += gliderGravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }

    void GroundMovement()
    {
        gliderGeo.SetActive(false);
        if(isGrounded)
            playerStamina.GainStamina(staminaRate);
        //Debug.Log("Stamina: " + playerStamina.stamina);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
          

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
