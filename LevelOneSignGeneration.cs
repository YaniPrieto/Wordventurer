using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSignGeneration : MonoBehaviour
{
    public GameObject[] SignPrefab;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, SignPrefab.Length);
        Instantiate(SignPrefab[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
