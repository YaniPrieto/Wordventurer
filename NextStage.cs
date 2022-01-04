using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public int healthGet;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && other.isTrigger)
        {
            GameUI.gameUI.Victory();

        }
    }
}
