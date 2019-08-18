using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTextScript : MonoBehaviour
{
    private Text text;
    private PlayerScripts player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScripts>();
        text = GetComponent<Text>();
        text.text = $"HP: {player.GetHP()}";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"HP: {player.GetHP()}";
    }
}
