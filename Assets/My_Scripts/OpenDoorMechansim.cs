using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorMechansim : MonoBehaviour
{
    public GameObject Door;
    public GameObject Guide;
    bool isTrigger;
    bool isOwnTriggerCondition;
    void Start()
    {
        isTrigger = false;
        isOwnTriggerCondition = false;
    }

    
    void Update()
    {

        if (isTrigger)
        {
            Guide.SetActive(true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (isOwnTriggerCondition)
                {
                    Door.SetActive(false);
                    print("已开门");
                }
                else
                {
                    print("无法开门");
                }
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
            isOwnTriggerCondition = collision.GetComponentsInChildren<PickableObject>()[0].TriggerCondition;
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
