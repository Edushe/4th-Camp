using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpPoints : MonoBehaviour
{
    // 要传送的位置
    public bool isTrigger; 
    public Transform anotherTpPonint;
    // 获取引导UI
    public GameObject Guide;
    // 获取玩家信息
    GameObject player;
    void Start()
    {
        isTrigger = false;
    }

    
    void Update()
    {
        if (isTrigger)
        {
            Guide.SetActive(true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                player.transform.position = anotherTpPonint.transform.position;
            }
        }
        else
        {
            Guide.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTrigger = true;
            player = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }
}
