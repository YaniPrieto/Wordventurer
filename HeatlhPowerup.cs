using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatlhPowerup : MonoBehaviour
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
            FindObjectOfType<NewAudioManager>().Play("HealthUp");
            playerHealth.HealthUp();
            Destroy(gameObject);
        }
    }
}
