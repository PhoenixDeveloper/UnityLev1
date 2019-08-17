using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Lib
{
    [NonSerialized] public static List<Texture2D> texture;
    private static List<KeyScript> keys;

    public static void Start()
    {
        texture = new List<Texture2D>();
        keys = new List<KeyScript>() { null };
        texture.Add(Texture2D.blackTexture);
        for (int i = 1; i < keys.Count; i++)
        {
            texture.Add(keys[i].spriteRenderer.sprite.texture);
        }
    }

    public static void AddKey(KeyScript key)
    {
        keys.Add(key);
        texture.Add(key.spriteRenderer.sprite.texture);
    }

    public static int GetCountKeys()
    {
        return keys.Count;
    }
}
