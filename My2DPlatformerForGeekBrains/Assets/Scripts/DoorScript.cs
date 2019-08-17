using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private GameObject leftDoor;
    private GameObject rightDoor;

    private void Start()
    {
        leftDoor = transform.GetChild(3).gameObject;
        rightDoor = transform.GetChild(1).gameObject;
    }

    public void OpenLeftDoor()
    {
        leftDoor.SetActive(false);
    }

    public void CloseLeftDoor()
    {
        leftDoor.SetActive(true);
    }

    public void OpenRightDoor()
    {
        rightDoor.SetActive(false);
    }

    public void CloseLRightDoor()
    {
        rightDoor.SetActive(true);
    }
}
