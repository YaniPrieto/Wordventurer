using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck01 : MonoBehaviour
{
    public StageOne_Manager s01;
    //This code is for box
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AnswerCheck")
        {
            s01.Door01();
        }
        if (other.tag == "AnswerCheck01")
        {

        }
        if (other.tag == "AnswerCheck01")
        {

        }
        if (other.tag == "AnswerCheck01")
        {

        }
        if (other.tag == "AnswerCheck01")
        {

        }


    }
}
