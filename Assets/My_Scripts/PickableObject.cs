using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool TriggerCondition = false;
    public GameObject Guide;
    bool isTrigger;
    GameObject PlayerInfo;
    Vector3 OriPos;
    void Start()
    {
        isTrigger = false;
        OriPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            Guide.SetActive(true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                PickableObject[] POs = PlayerInfo.GetComponentsInChildren<PickableObject>();
                if (POs.Length == 0)
                {
                    transform.SetParent(PlayerInfo.transform);
                    transform.position = PlayerInfo.transform.up;
                }
                else
                {
                    POs[0].transform.SetParent(null);
                    POs[0].transform.position = POs[0].GetComponent<PickableObject>().OriPos;
                    transform.SetParent(PlayerInfo.transform);
                    transform.position = PlayerInfo.transform.up;
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
            PlayerInfo = collision.gameObject;
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
