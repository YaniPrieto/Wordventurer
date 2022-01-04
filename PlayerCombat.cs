using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public int damage;


    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyScript enemyscript;
            enemyscript = other.gameObject.GetComponent<EnemyScript>();
            enemyscript.TakeDamage(damage);

        }


    }
    public void DamageUp()
    {
        damage = damage + 1;
    }
}