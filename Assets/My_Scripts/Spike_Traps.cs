using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Traps : MonoBehaviour
{
    // »÷·ÉÁ¦¶È
    public float HitForce = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().currentHealth -= 2;
            collision.GetComponent<Rigidbody2D>().AddForce(collision.transform.up * HitForce, ForceMode2D.Impulse);
        }
    }
}
