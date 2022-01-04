using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{

    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    private Animator anim;
    // RaycastHit2D grabCheck;
    public bool triggered;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (triggered == true)
            {
                anim.SetBool("isHolding", true);
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                anim.SetBool("isHolding", false);
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                anim.SetBool("isHolding", true);
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {

                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                anim.SetBool("isHolding", false);
            }
        }
    }
    public void buttonClick()
    {
        triggered = true;
    }
    public void buttonUnClick()
    {
        triggered = false;
    }


}
