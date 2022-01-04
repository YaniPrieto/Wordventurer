using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    public TutorialManager tutorial;

    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AnswerCheck01")
        {
            tutorial.DonePuzzle();
        }

    }
}
