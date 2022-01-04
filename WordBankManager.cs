using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WordBankManager : MonoBehaviour
{
    public string[] words;
    public string[] tow;
    public string[] description;
    int counter = 0;
    public TMP_Text wordText01, towText01, DescText01;


    // Start is called before the first frame update
    void Start()
    {
        wordText01.text = "Word Bank";
        towText01.text = "";
        DescText01.text = "Click the right button to next page!";
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void NextPage()
    {
        if (counter < words.Length && counter != words.Length)
        {
            wordText01.text = words[counter];
            towText01.text = tow[counter];
            DescText01.text = description[counter];
            counter++;
            Debug.Log("Page Next: " + counter);


        }

    }
    public void PrevPage()
    {
        if (counter > 0 && counter != 0)
        {
            wordText01.text = words[counter];
            towText01.text = tow[counter];
            DescText01.text = description[counter];
            counter--;
            Debug.Log("Page Back: " + counter);

        }

        // towText.text = tow[counter];
        // DescText.text = description[counter];



        // towText01.text = tow[counter];
        // DescText01.text = description[counter];

    }
    public void BackToMain()
    {
        SceneManager.LoadScene("Mode");
    }

}
