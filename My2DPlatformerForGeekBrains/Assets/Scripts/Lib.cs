using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lib : MonoBehaviour
{
    [NonSerialized] public List<Texture2D> texture;
    [SerializeField] private List<KeyScript> keys;

    private void Awake()
    {
        texture = new List<Texture2D>();
        texture.Add(Texture2D.blackTexture);
        for (int i = 1; i < keys.Count; i++)
        {
            texture.Add(keys[i].spriteRenderer.sprite.texture);
        }
    }
}
