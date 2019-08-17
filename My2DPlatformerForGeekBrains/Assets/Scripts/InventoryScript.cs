using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private int[] items;
    private int mouseSlot;
    [SerializeField] private int sizeInventory = 5;

    private void Awake()
    {
        Lib.Start();
    }

    private void Start()
    {
        items = new int[sizeInventory];
    }

    private void OnGUI()
    {
        for (int row = 0; row < sizeInventory / 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (GUI.Button(new Rect(col * 50+(Screen.width / 2 - 125), row * 50, 50, 50), Lib.texture[items[col+row*5]]))
                {
                    int loc = items[col + row * 5];
                    items[col + row * 5] = mouseSlot;
                    mouseSlot = loc;
                }
            }
        }
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 50, 50), Lib.texture[mouseSlot]);
    }

    /// <summary>
    /// Метод для изменения размера инвентаря
    /// </summary>
    /// <param name="newSize">Новый размер инвентаря (должен быть кратным 5(пяти))</param>
    public void ChangeSizeInventory(int newSize)
    {
        if (newSize % 5 == 0)
        {
            sizeInventory = newSize;
            Array.Resize(ref items, newSize);
        }
        else
        {
            Debug.Log("Размер массива должен быть кратным пяти");
        }
    }

    public void AddItemInIntentory(KeyScript key)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == 0)
            {
                items[i] = key.indexKey;
                return;
            }
        }
        Debug.Log("Нет свободного места");
    }
}
