using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Choice01 : MonoBehaviour
{

    // This is for Multiple Choice Box called Catharsis
    public bool oneTime = false;
    public bool opener = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneTime == false)
        {
            oneTime = true;
        }

        if (other.tag == "PC_Check01")
        {
            Debug.Log("Trigger PC");
            opener = true;

        }
    }
    public bool GetOpener()
    {
        return opener;
    }


}
