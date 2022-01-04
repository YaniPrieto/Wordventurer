using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionSign : MonoBehaviour
{

    [TextArea(3, 10)]
    public string text;
    public TMP_Text Text;
    public GameObject signz;
    public LayerMask whatIsPlayer;
    public float checkRadius;
    public bool isRange;

    void Start()
    {

        if (Text == null)
        {
            return;
        }
        else
        {
            Text.text = text;
        }
        signz.SetActive(false);
    }
    void Update()
    {
        isRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
    }
    void FixedUpdate()
    {
        if (isRange)
        {
            signz.SetActive(true);
        }
        else
        {
            signz.SetActive(false);
        }
    }


}
