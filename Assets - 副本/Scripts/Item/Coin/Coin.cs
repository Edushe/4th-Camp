using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//����ҽӴ�����ҵ���ײ��ʱ
    {
        UIManager.Instance.coinCount++;//�����������

        gameObject.SetActive(false);//����������
    }
}
