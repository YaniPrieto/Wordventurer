using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PictureSign : MonoBehaviour
{

    public string text;
    public TMP_Text Text;
    public GameObject image;

    void Start()
    {
        Text.text = text;
        image.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            image.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            image.SetActive(false);
        }

    }

}
