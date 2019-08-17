using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10;
    public float damage = 5;
    private SpriteRenderer spritePlayer;
    private bool direction;

    private void Start()
    {
        spritePlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>();
        direction = spritePlayer.flipX;
    }

    void Update()
    {
        if (direction)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }        
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
