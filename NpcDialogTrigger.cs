using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogTrigger : MonoBehaviour
{

    public NPCDialog dialogue;
    public bool onRange;
    public GameObject alert;
    public float checkRadius;
    private bool isRange;
    public LayerMask whatIsPlayer;
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }

    void Start()
    {
        alert.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (onRange)
        {
            TriggerDialog();
        }


    }
    void Update()
    {
        isRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

    }
    private void FixedUpdate()
    {
        if (isRange)
        {
            alert.SetActive(true);
            onRange = true;

        }
        else
        {
            alert.SetActive(false);
            onRange = false;
        }
    }



}
