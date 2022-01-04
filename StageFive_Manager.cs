using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageFive_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorSetActive door;
    public int counter;
    public Text progressText;
    public BossManager bm;
    public GameObject bossText;

    void Start()
    {
        FindObjectOfType<NewAudioManager>().Pause("bossbgm");
    }

    // Update is called once per frame
    void Update()
    {


    }
    public IEnumerator bossTransition()
    {
        bossText.SetActive(true);
        yield return new WaitForSeconds(5f);
        bossText.SetActive(false);
    }
    public void BossStart()
    {
        FindObjectOfType<NewAudioManager>().Play("bossbgm");
        StartCoroutine(bossTransition());
    }
    public void DoorTrigger()
    {
        door.openDoor();
    }
    public void SolvePuzzle()
    {
        counter++;
        StartCoroutine(ShowProgress());
        bm.Damage();

    }
    public void StageDone()
    {

    }
    private IEnumerator ShowProgress()
    {
        Debug.Log("Trigger");
        progressText.text = counter + " /10";
        yield return new WaitForSeconds(5);
        progressText.text = "";

    }
}
