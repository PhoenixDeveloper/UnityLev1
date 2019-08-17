using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x-((player.transform.position.x-this.transform.position.x)/2), player.transform.position.y - ((player.transform.position.y - this.transform.position.y) / 2), this.transform.position.z);
    }
}
