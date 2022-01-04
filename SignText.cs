using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignText : MonoBehaviour
{

    public Text showQuestion;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        showQuestion.text = null;
        showQuestion.text = "";
        showQuestion.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            showQuestion.gameObject.SetActive(true);
            showQuestion.text = text;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            showQuestion.text = null;
            showQuestion.text = "";
        }

    }

}
