using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRespawnPosition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//����ҽӴ����ø�������ײ��ʱ
    {
        GameObject.Find("ReSpawnPoints").GetComponent<PlayerRespawn>().point = transform;//����ǰ���������Ϊ�ø����
    }

    private void Update()
    {
        //�������¼�������ɫ״̬
        if (GameObject.Find("ReSpawnPoints").GetComponent<PlayerRespawn>().point == transform)//���ø����Ϊ��ǰ�����ʱ
            GetComponent<SpriteRenderer>().color = Color.green;//��������Ϊ��ɫ����ʾ�Ѽ���)
        else GetComponent<SpriteRenderer>().color = Color.white;//����������Ϊ��ɫ����ʾδ���
    }

}
