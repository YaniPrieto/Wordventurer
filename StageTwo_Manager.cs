using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTwo_Manager : MonoBehaviour
{
    public DoorSetActive door;
    public int counter;
    public Text progressText;
    public bool demo;
    public GameObject stageUI;
    // Start is called before the first frame update
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
    public void Stage2Door()
    {
        door.openDoor();
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
    private IEnumerator ShowProgress()
    {

        Debug.Log("Trigger");
        progressText.text = counter + " /5";
        yield return new WaitForSeconds(5);
        progressText.text = "";
    }
    private void Update()
    {
        if (counter == 4)
        {
            Stage2Door();
        }
        if (counter == 5)
        {
            if (!demo)
            {
                StageComplete();
            }
            else
            {

            }

        }
    }

}
