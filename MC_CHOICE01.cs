using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_CHOICE01 : MonoBehaviour
{

    // This is for Multiple Choice Box called Catharsis
    public bool oneTime = false;
    public bool opener = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneTime == false)
        {
            FindObjectOfType<NewAudioManager>().Play("CatharsisSound");
            oneTime = true;
        }

        if (other.tag == "MC_Check01")
        {
            Debug.Log("Trigger MC");
            opener = true;

        }
    }
    public bool GetOpener()
    {
        return opener;
    }


}
