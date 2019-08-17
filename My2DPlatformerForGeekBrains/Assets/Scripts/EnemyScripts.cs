﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    GameObject player;

    public float speedMove = 30.0f;

    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;
    public GameObject bullet;
    private Transform spawnBulletPoint;
    private Vector3 spawnBulletPointFlipXTrue;
    private Vector3 spawnBulletPointFlipXFalse;
    private DateTime recharge = DateTime.Now;
    public float rechargeInMilliseconds = 1500;

    [SerializeField] private float hp = 50;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        spawnBulletPoint = transform.Find("SpawnBulletPoint");
        spawnBulletPointFlipXFalse = new Vector3(spawnBulletPoint.localPosition.x, spawnBulletPoint.localPosition.y, spawnBulletPoint.localPosition.y);
        spawnBulletPointFlipXTrue = new Vector3((-1) * spawnBulletPoint.localPosition.x, spawnBulletPoint.localPosition.y, spawnBulletPoint.localPosition.y);
    }

    void Update()
    {
        float direction = player.transform.position.x - transform.position.x;

        if (Mathf.Abs(direction) < 8 && Mathf.Abs(direction) > 5)
        {
            Vector3 pos = transform.position;
            pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime;
            transform.position = pos;                       
        }

        sprite.flipX = direction < 0.0F;
        if (sprite.flipX)
        {
            spawnBulletPoint.localPosition = spawnBulletPointFlipXTrue;
        }
        else
        {
            spawnBulletPoint.localPosition = spawnBulletPointFlipXFalse;
        }

        if (Mathf.Abs(direction) <= 4 && ((DateTime.Now - recharge).TotalMilliseconds > 1500))
        {
            recharge = DateTime.Now;
            Shoot();
        }
    }

    private void Shoot()
    {
        var newBullet = GameObject.Instantiate(bullet, spawnBulletPoint.position, Quaternion.identity);
        Destroy(newBullet, 3);
    }

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
