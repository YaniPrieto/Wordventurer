using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageFour_Manager : MonoBehaviour
{
    public DoorSetActive[] door;
    public int counter;
    public Text progressText;
    public GameObject stageUI;

    void Start()
    {
        StartCoroutine(stageTransition());
    }
    public IEnumerator stageTransition()
    {

        yield return new WaitForSeconds(.5f);
        stageUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        stageUI.SetActive(false);
    }
    public void Stage04Door()
    {
        if (counter == 1)
        {
            door[counter - 1].openDoor();
        }
        if (counter == 2)
        {
            door[counter - 1].openDoor();
        }
        if (counter == 3)
        {
            door[counter - 1].openDoor();
        }
        if (counter == 4)
        {
            door[counter - 1].openDoor();
        }
        if (counter == 5)
        {
            StageComplete();
        }

    }

    void StageComplete()
    {
        GameUI.gameUI.Victory();
    }
    public void SolvePuzzle()
    {
        counter++;
        StartCoroutine(ShowProgress());
    }
    private IEnumerator ShowProgress()
    {
        Debug.Log("Trigger");
        progressText.text = counter + " /5";
        yield return new WaitForSeconds(5);
        progressText.text = "";

    }

    void Update()
    {
        Stage04Door();
    }
}
