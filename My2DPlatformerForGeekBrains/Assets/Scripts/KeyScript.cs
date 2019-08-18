using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public enum Door
    {
        Blue,
        Yellow
    }

    [NonSerialized] public SpriteRenderer spriteRenderer;
    [NonSerialized] public int indexKey;
    public Door openDoor;
    private InventoryScript inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<InventoryScript>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        indexKey = Lib.GetCountKeys();
        Lib.AddKey(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventory.AddItemInIntentory(this);
            Destroy(gameObject);
        }

    }
}
