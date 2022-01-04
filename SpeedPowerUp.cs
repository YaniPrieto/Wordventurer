using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && other.isTrigger)
        {

            TopViewPlayerMovement speed;
            speed = other.gameObject.GetComponent<TopViewPlayerMovement>();
            speed.SpeedUp();
            FindObjectOfType<NewAudioManager>().Play("PowerGet");
            Destroy(gameObject);
        }
    }

}
