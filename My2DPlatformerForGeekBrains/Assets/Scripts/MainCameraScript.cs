using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    GameObject player;
    float cameraSize;
    GameObject endLine;
    float rightBoards;
    float rightBoardsPog;
    float leftBoards;
    float leftBoardsPog;
    float topBoards;
    float topBoardsPog;
    float bottomBoards;
    float bottomBoardsPog;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        endLine = GameObject.FindGameObjectWithTag("EndLine");
        rightBoards = endLine.transform.GetChild(3).position.x;
        rightBoardsPog = endLine.transform.GetChild(3).GetComponent<BoxCollider2D>().size.x / 2;
        leftBoards = endLine.transform.GetChild(2).position.x;
        leftBoardsPog = endLine.transform.GetChild(2).GetComponent<BoxCollider2D>().size.x / 2;
        topBoards = endLine.transform.GetChild(1).position.y;
        topBoardsPog = endLine.transform.GetChild(1).GetComponent<BoxCollider2D>().size.y / 2;
        bottomBoards = endLine.transform.GetChild(0).position.y;
        bottomBoardsPog = endLine.transform.GetChild(0).GetComponent<BoxCollider2D>().size.y / 2;
        cameraSize = gameObject.GetComponent<Camera>().orthographicSize / 2;
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }

    private void FixedUpdate()
    {
        // проверка на переход за границу правого края
        if (player.transform.position.x + (cameraSize) >= rightBoards - rightBoardsPog)
        {
            // проверка на переход за границу верхнего края
            if (player.transform.position.y + (cameraSize) >= topBoards - topBoardsPog)
            {
                transform.position = new Vector3(rightBoards - (rightBoardsPog) - (cameraSize), topBoards - (topBoardsPog) - (cameraSize) - 1, this.transform.position.z);
                return;
            }

            // проверка на переход за границу нижнего края
            if (player.transform.position.y - (cameraSize) <= bottomBoards + bottomBoardsPog)
            {
                transform.position = new Vector3(rightBoards - (rightBoardsPog) - (cameraSize), bottomBoards + bottomBoardsPog + (cameraSize) + 1, this.transform.position.z);
                return;
            }

            transform.position = new Vector3(rightBoards - (rightBoardsPog) - (cameraSize), player.transform.position.y - ((player.transform.position.y - this.transform.position.y) / 2), this.transform.position.z);
            return;
        }

        // проверка на переход за границу левого края
        if (player.transform.position.x - (cameraSize) <= leftBoards + leftBoardsPog)
        {
            // проверка на переход за границу верхнего края
            if (player.transform.position.y + (cameraSize) >= topBoards - topBoardsPog)
            {
                transform.position = new Vector3(leftBoards + (leftBoardsPog) + (cameraSize), topBoards - (topBoardsPog) - (cameraSize) - 1, this.transform.position.z);
                return;
            }

            // проверка на переход за границу нижнего края
            if (player.transform.position.y - (cameraSize) <= bottomBoards + bottomBoardsPog)
            {
                transform.position = new Vector3(leftBoards + (leftBoardsPog) + (cameraSize), bottomBoards + (bottomBoardsPog) + (cameraSize) + 1, this.transform.position.z);
                return;
            }

            transform.position = new Vector3(leftBoards + (leftBoardsPog) + (cameraSize), player.transform.position.y - ((player.transform.position.y - this.transform.position.y) / 2), this.transform.position.z);
            return;
        }

        // проверка на переход за границу верхнего края
        if (player.transform.position.y + (cameraSize) >= topBoards - topBoardsPog)
        {
            transform.position = new Vector3(player.transform.position.x - ((player.transform.position.x - this.transform.position.x) / 2), topBoards - (topBoardsPog) - (cameraSize) - 1, this.transform.position.z);
            return;
        }

        // проверка на переход за границу нижнего края
        if (player.transform.position.y - (cameraSize) <= bottomBoards + bottomBoardsPog)
        {
            transform.position = new Vector3(player.transform.position.x - ((player.transform.position.x - this.transform.position.x) / 2), bottomBoards + (bottomBoardsPog) + (cameraSize) + 1, this.transform.position.z);
            return;
        }


        transform.position = new Vector3(player.transform.position.x-((player.transform.position.x-this.transform.position.x)/2), player.transform.position.y - ((player.transform.position.y - this.transform.position.y) / 2), this.transform.position.z);
    }
}
