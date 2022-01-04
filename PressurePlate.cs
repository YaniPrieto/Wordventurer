using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Box" || other.tag == "Player")
        {
            FindObjectOfType<NewAudioManager>().Play("PressurePlate");
            animator.SetBool("Collide", true);

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Collide", false);
    }
}
