using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    public float speed = 10;
    public float jumpForce = 5;
    private Rigidbody2D rigidbodyObject;
    private SpriteRenderer sprite;
    [SerializeField] private GameObject bullet;
    private Transform spawnBulletPoint;
    private Vector3 spawnBulletPointFlipXTrue;
    private Vector3 spawnBulletPointFlipXFalse;

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
        spawnBulletPoint = transform.Find("SpawnBulletPoint");
        spawnBulletPointFlipXFalse = new Vector3(spawnBulletPoint.localPosition.x, spawnBulletPoint.localPosition.y, spawnBulletPoint.localPosition.y);
        spawnBulletPointFlipXTrue = new Vector3((-1)*spawnBulletPoint.localPosition.x, spawnBulletPoint.localPosition.y, spawnBulletPoint.localPosition.y);
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Shoot();
        }
    }

    public float GetHP()
    {
        return hp;
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

    private void Shoot()
    {
        var newBullet = GameObject.Instantiate(bullet, spawnBulletPoint.position, Quaternion.identity);
        Destroy(newBullet, 3);
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
        if (sprite.flipX)
        {
            spawnBulletPoint.localPosition = spawnBulletPointFlipXTrue;
        }
        else
        {
            spawnBulletPoint.localPosition = spawnBulletPointFlipXFalse;
        }
    }

    private void Jump()
    {
        rigidbodyObject.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
