using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignDetector02 : MonoBehaviour
{
    public Text showQuestion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        showQuestion.text = "deliberately cruel or violent.";
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        showQuestion.text = "";
    }

    void Update()
    {

    }
}
