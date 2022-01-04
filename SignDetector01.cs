using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignDetector01 : MonoBehaviour
{
    public Text showQuestion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        showQuestion.text = "lacking excitement or variety; dull; monotonous";
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        showQuestion.text = "";
    }

    void Update()
    {

    }
}
