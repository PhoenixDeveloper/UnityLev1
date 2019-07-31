using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    [SerializeField] private float hp = 50;

    private void FixedUpdate()
    {
        if (hp<=0)
        {
            Destroy(gameObject, 1);
        }
    }

    public void TakeDamage(float damage)
    {
        hp = hp - damage;
    }
}
