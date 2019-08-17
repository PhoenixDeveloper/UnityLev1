using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLineScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScripts>().Die();
            return;
        }
        Destroy(collision.gameObject);
    }
}
