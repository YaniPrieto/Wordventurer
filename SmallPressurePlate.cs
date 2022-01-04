using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    public StageThree_Manager manager;
    public string correct;
    private bool trigger;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SmallBox")
        {
            SmallBoxScript smallBox;
            smallBox = other.gameObject.GetComponent<SmallBoxScript>();
            if (string.Equals(correct, smallBox.alphabet) && !trigger)
            {
                trigger = true;
                // manager.Checker();
            }


        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        trigger = false;
    }
}
