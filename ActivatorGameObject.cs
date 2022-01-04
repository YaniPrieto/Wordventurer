using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorGameObject : MonoBehaviour
{
    public GameObject[] enemySpawn;
    int size;
    // Start is called before the first frame update
    void Start()
    {

        size = enemySpawn.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            for (int i = 0; i < size; i++)
            {
                enemySpawn[i].SetActive(true);

            }
            Destroy(gameObject);

        }
    }
}
