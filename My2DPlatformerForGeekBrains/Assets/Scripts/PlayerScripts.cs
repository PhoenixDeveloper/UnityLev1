using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 5;
    private Rigidbody2D rigidbodyObject;
    private SpriteRenderer sprite;

    //находится ли персонаж на земле или в прыжке?
    private bool isGrounded = false;
    //радиус определения соприкосновения с землей
    private float groundRadius = 0.5f;
    //ссылка на слой, представляющий землю
    private LayerMask whatIsGround;


    private void Awake()
    {
        rigidbodyObject = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        whatIsGround = LayerMask.GetMask("Blocks", "Enemy");
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.rotation.z) > 0.05f)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, transform.rotation.w);
        }
        isGrounded = Physics2D.OverlapCircle(transform.position, groundRadius, whatIsGround);
        if (isGrounded)
        {
            var moveHorizontal = Input.GetAxis("Horizontal");

            if (moveHorizontal != 0)
            {
                Move(moveHorizontal);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        
    }

    private void Move(float move)
    {       
        if (move > 0)
        {
            rigidbodyObject.AddForce(transform.right * speed, ForceMode2D.Force);
        }

        if (move < 0)
        {
            rigidbodyObject.AddForce(-transform.right * speed, ForceMode2D.Force);
        }

        sprite.flipX = move < 0.0F;
    }

    private void Jump()
    {
        rigidbodyObject.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
