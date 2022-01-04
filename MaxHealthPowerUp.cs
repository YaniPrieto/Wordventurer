using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthPowerUp : MonoBehaviour
{

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.isTrigger)
        {
            HealthScript playerHealth;
            FindObjectOfType<NewAudioManager>().Play("Heal");
            playerHealth = other.gameObject.GetComponent<HealthScript>();
            playerHealth.MaxHealthUp();
            Destroy(gameObject);
        }
    }
}
