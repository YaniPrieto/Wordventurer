using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPCDialog
{

    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    public Sprite npcPics1, npcPics2;
}
