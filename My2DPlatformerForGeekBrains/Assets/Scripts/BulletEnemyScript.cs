using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{
    GameObject player;
    new private Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float damage = 5;
    private bool direction;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        rigidbody2D = GetComponent<Rigidbody2D>();
        direction = player.transform.position.x - transform.position.x < 0.0f;
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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScripts>().TakeDamage(damage);
        }        
        Destroy(gameObject);
    }
}
