using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public int health, numOfHearts;
    public Sprite fullHeart, EmptyHeart;
    public Color inv;
    public Image[] hearts;
    public GameObject player, camera;
    bool invumode;

    private SpriteRenderer playerSprite;

    public Color flashColor, InvuColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;


    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();

        inv.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void PlayerTakeDamage(int enemyDamage)
    {
        StartCoroutine(FlashCo(enemyDamage));
    }
    private IEnumerator FlashCo(int enemyDamage)
    {

        if (health <= 0)
        {
            playerSprite.color = inv;
            camera.transform.parent = null;
            GameUI.gameUI.GameOver();

        }
        if (!invumode)
        {
            health -= enemyDamage;
            int temp = 0;
            FindObjectOfType<NewAudioManager>().Play("Hit");
            triggerCollider.enabled = false;
            while (temp < numberOfFlashes)
            {
                playerSprite.color = flashColor;
                yield return new WaitForSeconds(flashDuration);
                playerSprite.color = regularColor;
                yield return new WaitForSeconds(flashDuration);
                temp++;
            }
            triggerCollider.enabled = true;

        }
    }
    private IEnumerator InvCo(int enemyDamage)
    {
        if (invumode == true)
        {
            int invutime = 0;
            triggerCollider.enabled = false;

            while (invutime < 50)
            {
                Debug.Log(invutime);
                playerSprite.color = InvuColor;
                yield return new WaitForSeconds(flashDuration);
                playerSprite.color = regularColor;
                yield return new WaitForSeconds(flashDuration);
                invutime++;
            }
            triggerCollider.enabled = true;
            invumode = false;
        }
    }


    public void HealthUp()
    {
        health = health + 1;
    }
    public void MaxHealthUp()
    {
        numOfHearts = numOfHearts + 1;
    }
    public void InvuUp()
    {
        invumode = true;
        StartCoroutine(InvCo(0));
    }
}
