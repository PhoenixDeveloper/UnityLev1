using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private int[] items;
    [SerializeField] private int sizeInventory = 5;
    private Lib library;

    private void Start()
    {
        library = GameObject.FindGameObjectWithTag("Library keys").GetComponent<Lib>();
        items = new int[sizeInventory];
        Debug.Log(items[sizeInventory - 1]);
    }

    private void OnGUI()
    {
        for (int row = 0; row < sizeInventory / 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                GUI.Button(new Rect(col * 50+(Screen.width / 2 - 125), row * 50, 50, 50), library.texture[items[col+row*5]]);
            }
        }
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
}
