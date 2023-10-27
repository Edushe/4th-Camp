using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    [Header("ҩˮ�ṩ��������")]
    public int recoverValue;
    private void OnTriggerEnter2D(Collider2D collision)//����ҽӴ�������ҩˮ����ײ��ʱ
    {
        if (collision.GetComponent<Character>().currentHealth == collision.GetComponent<Character>().maxHealth) return;//����ǰ��Ѫ���򲻽���ʹ��

        if (collision.GetComponent<Character>().currentHealth + recoverValue > collision.GetComponent<Character>().maxHealth)//�����������
            collision.GetComponent<Character>().currentHealth = collision.GetComponent<Character>().maxHealth;//��ָ����������ֵ
        else 
            collision.GetComponent<Character>().currentHealth += recoverValue;//���򣬻ָ���������������ֵ

        gameObject.SetActive(false);//����������
    }
}
