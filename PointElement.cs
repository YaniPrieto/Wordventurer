using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointElement : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text highscore;

    public void NewPointElement(string _username, int _highscore)
    {
        usernameText.text = _username;
        highscore.text = _highscore.ToString();
    }

}
