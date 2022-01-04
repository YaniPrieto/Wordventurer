using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int enemyDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // private void OnCollisionEnter2D(Collision2D other) {
    //      if(other.collider.tag == "Player") {
    //     HealthScript playerHealth;
    //     playerHealth = other.gameObject.GetComponent<HealthScript>();
    //     playerHealth.PlayerTakeDamage(enemyDamage);
    //      }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && other.isTrigger)
        {
            Debug.Log("Hit!");
            HealthScript playerHealth;
            playerHealth = other.gameObject.GetComponent<HealthScript>();
            playerHealth.PlayerTakeDamage(enemyDamage);
        }
    }


}
