using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignDetector03 : MonoBehaviour
{
    public Text showQuestion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        showQuestion.text = "the process of releasing, and thereby providing relief from, strong or repressed emotions.";
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        showQuestion.text = "";
    }

    void Update()
    {

    }
}
