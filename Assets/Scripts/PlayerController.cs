using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpPower;
    public bool isGround;
    public Collider2D Platform;

    [Header("Animation")]
    public Animator animator;

    private new Rigidbody2D rigidbody2D;
    private new Transform transform;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private Vector3 spawn;

    void Start()
    {
        spawn = GetComponent<Transform>().position;
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        player = GetComponent<GameObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        if(horizontal < 0)
        {
            animator.SetBool("IsRun", true);
            spriteRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            animator.SetBool("IsRun", true);
            spriteRenderer.flipX = false;
        }
        else if(horizontal == 0)
        {
            animator.SetBool("IsRun", false);
        }

        rigidbody2D.velocity = new Vector2(horizontal * Speed, rigidbody2D.velocity.y);

        if(vertical > 0.0f && isGround)
        {
            animator.SetBool("IsJump", true);

            rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse); 
            isGround = false;
            
        }
        else if(vertical < 0.0f && isGround)
        {
            animator.SetBool("IsCrouch", true);
            Platform.enabled = false;
            isGround = false;   
        }
        else if(vertical == 0.0f && isGround)
        {
            animator.SetBool("IsCrouch", false);
            animator.SetBool("IsJump", false);  
        }
        
    }
    
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            isGround = true;
        }
        if(other.gameObject.tag == "Ground" && Platform.enabled == false)
        {
            Platform.enabled = true;
        }

        //respawn
        if(other.gameObject.tag == "Water")
        {
            transform.position = spawn;
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            isGround = false;
        }
    }
}
