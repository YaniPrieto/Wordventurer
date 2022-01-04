using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBox : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickup;
    public Vector3 Direction { get; set; }
    GameObject itemHolding;
    private TopViewPlayerMovement player;
    void Start()
    {
        player = gameObject.GetComponent<TopViewPlayerMovement>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (itemHolding)
            {
                Debug.Log("Trigger");
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
                player.moveSpeed = player.tempSpeed;
            }
            else
            {
                Collider2D pickupItem = Physics2D.OverlapCircle(transform.position + Direction, 2f, pickup);
                Debug.Log("Boolshit");
                if (pickupItem)
                {
                    itemHolding = pickupItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                    player.moveSpeed = 5f;
                }
            }
        }

    }
    public void Grab()
    {
        if (itemHolding)
        {
            itemHolding.transform.position = transform.position + Direction;
            itemHolding.transform.parent = null;
            if (itemHolding.GetComponent<Rigidbody2D>())
                itemHolding.GetComponent<Rigidbody2D>().simulated = true;
            itemHolding = null;
            FindObjectOfType<NewAudioManager>().Play("DropBox");
            player.moveSpeed = player.tempSpeed;
        }
        else
        {
            Collider2D pickupItem = Physics2D.OverlapCircle(transform.position + Direction, 2f, pickup);
            Debug.Log("Boolshit");
            if (pickupItem)
            {
                itemHolding = pickupItem.gameObject;
                itemHolding.transform.position = holdSpot.position;
                itemHolding.transform.parent = transform;
                FindObjectOfType<NewAudioManager>().Play("GetBox");
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                player.moveSpeed = 5f;
            }
        }


    }

}
