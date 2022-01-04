using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] BoxPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, BoxPrefab.Length);
        Instantiate(BoxPrefab[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
