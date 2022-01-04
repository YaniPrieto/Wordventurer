using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // public float thrust;
    private Rigidbody2D rb;
    public static Knockback instance;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("Enemy")) {
    //         Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
    //         if(enemy != null) {
    //             enemy.isKinematic = false;
    //             Vector2 difference = enemy.transform.position - transform.position;
    //             difference = difference.normalized * thrust;
    //             enemy.AddForce(difference, ForceMode2D.Impulse);
    //             enemy.isKinematic = true;
    //         }
    //     }
    // }
    public IEnumerator KnockBackAttack(float knockbackDuration,float knockbackPower, Transform obj){
        float timer = 0;
        while (knockbackDuration > timer) {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }
        yield return 0;
    }
}
