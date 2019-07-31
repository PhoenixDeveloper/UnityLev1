using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{
    GameObject player;
    public float speed = 10;
    public float damage = 5;
    private bool direction;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        direction = player.transform.position.x - transform.position.x < 0.0f;
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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScripts>().TakeDamage(damage);
        }        
        Destroy(gameObject);
    }
}
