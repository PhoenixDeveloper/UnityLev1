using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    public float speed = 450;
    public float maxSpeed = 3;
    public float jumpForce = 500;
    private Rigidbody2D rigidbodyObject;
    private SpriteRenderer sprite;
    public GameObject bullet;
    private Transform spawnBulletPoint;
    private Animator animator;
    private Vector3 spawnBulletPointFlipXTrue;
    private Vector3 spawnBulletPointFlipXFalse;

    private DateTime recharge;
    public float rechargeInMilliseconds = 300;

    //находится ли персонаж на земле или в прыжке?
    private bool isGrounded = false;
    //радиус определения соприкосновения с землей
    private float groundRadius = 1.5f;
    //ссылка на слой, представляющий землю
    private LayerMask whatIsGround;


    private void Awake()
    {
        rigidbodyObject = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        whatIsGround = LayerMask.GetMask("Blocks", "Enemy");
        spawnBulletPoint = transform.Find("SpawnBulletPoint");
        spawnBulletPointFlipXFalse = new Vector3(spawnBulletPoint.localPosition.x, spawnBulletPoint.localPosition.y, spawnBulletPoint.localPosition.y);
        spawnBulletPointFlipXTrue = new Vector3((-1)*spawnBulletPoint.localPosition.x, spawnBulletPoint.localPosition.y, spawnBulletPoint.localPosition.y);
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && ((DateTime.Now - recharge).TotalMilliseconds > rechargeInMilliseconds))
        {
            recharge = DateTime.Now;
            Shoot();
        }
    }

    public float GetHP()
    {
        return hp;
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            Die();
        }

        isGrounded = Physics2D.OverlapCircle(transform.position, groundRadius, whatIsGround);

        if (isGrounded)
        {
            var moveHorizontal = Input.GetAxis("Horizontal");

            if (moveHorizontal != 0)
            {
                animator.SetBool("isRun", true);
                Move(moveHorizontal);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("isJump", true);
                Jump();
            }

            if (rigidbodyObject.velocity.x == 0 && rigidbodyObject.velocity.y == 0)
            {
                animator.SetBool("isJump", false);
                animator.SetBool("isRun", false);
            }
        }
        
    }

    public void TakeDamage(float damage)
    {
        hp = hp - damage;
    }

    private void Shoot()
    {
        var newBullet = GameObject.Instantiate(bullet, spawnBulletPoint.position, Quaternion.identity);
        Destroy(newBullet, 3);
    }

    private void Move(float move)
    {
        if (Mathf.Abs(rigidbodyObject.velocity.x) < maxSpeed)
        {
            if (move > 0)
            {
                rigidbodyObject.AddForce(transform.right * speed * Time.deltaTime);
            }

            if (move < 0)
            {
                rigidbodyObject.AddForce(-transform.right * speed * Time.deltaTime);
            }

            sprite.flipX = move < 0.0F;
            if (sprite.flipX)
            {
                spawnBulletPoint.localPosition = spawnBulletPointFlipXTrue;
            }
            else
            {
                spawnBulletPoint.localPosition = spawnBulletPointFlipXFalse;
            }
        }
    }

    private void Jump()
    {
        rigidbodyObject.AddForce(transform.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
