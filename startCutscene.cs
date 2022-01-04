using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startCutscene : MonoBehaviour
{
    // public PlayableDirector tl1;
    // public PlayableDirector tl2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            SceneManager.LoadScene("AfterLvl2_2");
            // level 2_2
        }
    }

}
