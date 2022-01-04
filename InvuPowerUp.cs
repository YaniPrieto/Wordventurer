using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvuPowerUp : MonoBehaviour
{

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.isTrigger)
        {
            HealthScript playerHealth;
            playerHealth = other.gameObject.GetComponent<HealthScript>();
            playerHealth.InvuUp();
            FindObjectOfType<NewAudioManager>().Play("PowerGet");
            Destroy(gameObject);
        }
    }
}
