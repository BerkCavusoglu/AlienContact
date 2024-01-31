using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public CharacterController Chcon;
    public float speed = 10f;
    public float gravity = -14;
    public float PlayerHealth = 100;

    private Vector3 gravityVector;

    //GroundCheck
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.35f;
    public LayerMask groundLayer;
    public bool isGrounded = false;
    public float jumpSpeed = 5f;
    //UI
    public Slider healthSlider;
    public Text HealthText;

    private GameManager gameManager;

    void Start()
    {
        Chcon = GetComponent<CharacterController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        MovePlayer();
        GroundCheck();
        JumpAndGravity();   

    }
    void MovePlayer()
    {
        Vector3 moveVector = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Chcon.Move(moveVector * speed * Time.deltaTime);

    }
    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }
    void JumpAndGravity()
    {
        gravityVector.y += gravity * Time.deltaTime;
        Chcon.Move(gravityVector * Time.deltaTime);

        if (isGrounded && gravityVector.y < 0)
        {
            gravityVector.y = -3f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVector.y = Mathf.Sqrt(jumpSpeed * 2f * gravity);
        }
    }
    public void PlayerTakeDamage(int DamageAmount)
    {
        PlayerHealth -= DamageAmount;
        healthSlider.value -= DamageAmount;
        HealthTextUpdate();
        if (PlayerHealth <= 0)
        {
            PlayerDeath();
            HealthTextUpdate();
            healthSlider.value = 0;
        }
    }
    void PlayerDeath()
    {
        gameManager.RestartGame();
    }
    void HealthTextUpdate()
    {
        HealthText.text = PlayerHealth.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
        }
        
    }
}
