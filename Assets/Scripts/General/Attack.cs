using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
//���й����Ļ�������
{
    [Header("��������")]
    [Tooltip("������")]
    public int attackDamage;//������
    [Tooltip("������Χ")]
    public float attackRange;//������Χ
    [Tooltip("����Ƶ��")]
    public float attackRate;//����Ƶ��

    private void OnTriggerStay2D(Collider2D collision)//�����������ý�ɫ������ײ��Χ��ʱ
    {
        collision.GetComponent<Character>()?.TakeDamage(this);
        //�ڸ��������ϵ�character����ڵ���(�޸�����򲻵���)TakeDamage����������֪���˵�һ����������˭
    }
}
