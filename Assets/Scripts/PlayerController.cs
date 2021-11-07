using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpPower;
    public bool isGround;
    public List<Toggle> toggleList;
    public Collider2D Platform;

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
            spriteRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        if(toggleList[0].isOn)
        {
            rigidbody2D.velocity = new Vector2(horizontal * Speed, rigidbody2D.velocity.y);
        }
        else if(toggleList[1].isOn)
        {
            rigidbody2D.AddForce(Vector2.right * horizontal * Speed / 5f);
        }
        else if(toggleList[2].isOn)
        {
            transform.Translate(Vector3.right * horizontal * Speed/1000f);
        }
        else if(toggleList[3].isOn)
        {
            rigidbody2D.MovePosition(transform.position + new Vector3(horizontal, 0, 0) * Time.deltaTime * Speed * 10f);
        }
        else if(toggleList[4].isOn)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(horizontal * Speed, 0f) * Time.fixedDeltaTime);
        }

        if(vertical > 0.0f && isGround)
        {
            rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse); 
            isGround = false;
        }
        else if(vertical < 0.0f && isGround)
        {
            Platform.enabled = false;
            isGround = false;   
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
