using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageOne_Manager : MonoBehaviour
{

    public DoorSetActive door;
    public int counter;
    public Text progressText;
    public bool demo;
    public GameObject stageUI;

    public void Door01()
    {

        door.openDoor();

    }
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

    private void StageComplete()
    {
        GameUI.gameUI.Victory();
    }
    public void SolvePuzzle()
    {
        counter++;
        StartCoroutine(ShowProgress());

    }
    void Update()
    {

        if (counter == 4 && demo == false)
        {
            StageComplete();

        }
        else if (counter == 4 && demo == true)
        {

            door.openDoor();
        }
    }
    private IEnumerator ShowProgress()
    {

        if (counter == 4)
        {
            progressText.text = "Proceed to the next level!";
        }
        else
        {
            progressText.text = counter + " /4";
        }

        yield return new WaitForSeconds(5);
        progressText.text = "";

    }



}
