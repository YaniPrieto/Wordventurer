using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;

public class ApiWordBank : MonoBehaviour
{
    //Part of Speech
    public TextMeshProUGUI wordText, posText, wordDefinition;
    public TMP_InputField searchbar;
    private readonly string basedictionaryURL = "https://api.dictionaryapi.dev/api/v2/entries/en/";
    // Start is called before the first frame update

    void Start()
    {
        wordText.text = "Search for a word!";
        posText.text = "";
        wordDefinition.text = "";
    }
    public void SearchButton()
    {
        string searched = searchbar.text;
        wordText.text = "Loading...";
        posText.text = "";
        wordDefinition.text = "";
        StartCoroutine(GetWordIndex(searched));
    }
    IEnumerator GetWordIndex(string searched)
    {
        //Get Word Info
        string wordURL = basedictionaryURL + searched;
        UnityWebRequest wordInfoRequest = UnityWebRequest.Get(wordURL);
        yield return wordInfoRequest.SendWebRequest();

        if (wordInfoRequest.isNetworkError || wordInfoRequest.isHttpError)
        {
            wordText.text = "No word found";
            Debug.LogError(wordInfoRequest.error);
            yield break;
        }
        //Array[0].word
        //Array[0].meanings[1].partOfSpeech
        // let firstName = userData["results"][0]["name"]["first"].stringValue
        JSONNode wordInfo = JSON.Parse(wordInfoRequest.downloadHandler.text);
        string wordName = wordInfo[0]["word"];
        string pos = wordInfo[0]["meanings"][0]["partOfSpeech"];
        string wordDesc = wordInfo[0]["meanings"][0]["definitions"][0]["definition"];
        //SET UI
        wordText.text = wordName;
        posText.text = pos;
        wordDefinition.text = wordDesc;
        Debug.Log(wordDesc);



    }

}
