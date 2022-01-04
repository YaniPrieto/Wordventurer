using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreElement : MonoBehaviour
{

    public Text usernameText;
    public Text killsText;
    public Text deathsText;
    public Text xpText;

    public void NewScoreElement(string _username, int _kills, int _deaths, int _xp)
    {
        usernameText.text = _username;
        killsText.text = _kills.ToString();
        deathsText.text = _deaths.ToString();
        xpText.text = _xp.ToString();
    }
}
