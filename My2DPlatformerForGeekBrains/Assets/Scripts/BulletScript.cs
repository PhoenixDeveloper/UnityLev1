using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10;
    public float damage = 5;
    private SpriteRenderer spritePlayer;
    new private Rigidbody2D rigidbody2D;
    private bool direction;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spritePlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>();
        direction = spritePlayer.flipX;
        if (direction)
        {
            rigidbody2D.AddForce(Vector2.left * speed);
        }
        else
        {
            rigidbody2D.AddForce(Vector2.right * speed);
        }
    }

    void Update()
    {     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScripts>().TakeDamage(damage);
        }        
        Destroy(gameObject);
    }
}
