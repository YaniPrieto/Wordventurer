using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager03 : MonoBehaviour
{
    public DoorSetActive door;
    public PC_Choice01 obox;
    public bool factChecker;
    private bool isDone = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        factChecker = obox.GetOpener();
        if (factChecker == true)
        {
            door.openDoor();
            if (isDone == false)
            {
                FindObjectOfType<NewAudioManager>().Play("MysteryFound");
                isDone = true;
            }
        }
        else
        {
            door.CloseDoor();
        }
    }
}
