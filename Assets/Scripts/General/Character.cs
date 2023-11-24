using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
    //���н�ɫ����Һ͵��ˣ��Ļ�������
{
    [Header("���н�ɫ�Ļ�������")]
    [Tooltip("�������ֵ")]
    public float maxHealth;//�������ֵ
    [Tooltip("��ǰ����ֵ")]
    public float currentHealth;//��ǰ����ֵ
    [Tooltip("��ǰ�Ƿ��������޵�״̬")]
    public bool isInvincible=false;//�Ƿ��������޵�״̬,Ĭ��Ϊ��
    [Tooltip("�����޵�ʱ��")]
    public float invincibleTime=0.5f;//�����޵�ʱ�䣬Ĭ��Ϊ0.5��
    float invincibleTimer;//���˼�ʱ��

    [Header("����ʱ�������¼�")]
    public UnityEvent<Transform> OnTakeDamage;//����ʱ�¼�(��Ҫ���빥������λ��)
    [Header("����ʱ�������¼�")]
    public UnityEvent OnDead;//����ʱ�¼�

    private void Start()
    {
        currentHealth = maxHealth;//��ʼ����ǰ����ֵ��ʹ������������ֵ
    }


    public void TakeDamage(Attack attacker)//�ܵ��˺�ʱ
    {
        if (isInvincible) return;//�����޵�״̬ʱ,��ִ�к���ָ��

        if(currentHealth>attacker.attackDamage)//��ʣ��Ѫ�����ڹ����ߵĹ�����
        {
            currentHealth -= attacker.attackDamage;//�۳��˺���Ӧ��Ѫ��
            HurtInvincible();//���������޵�״̬
            OnTakeDamage?.Invoke(attacker.transform);
            //���������¼�����ҵ��¼�Ϊ���������˶�������ұ�����Ч����������֪���˵�һ�������ߵ�λ��
        }
        else //����
        {
            currentHealth = 0;//Ѫ����0
            OnDead?.Invoke();
            //���������¼�����ҵ��¼�Ϊ����������������
        }
    }
    public void HurtInvincible()//�����޵�
    {
        isInvincible = true;//����Ϊ�޵�״̬
        
        invincibleTimer = invincibleTime;//���������޵е���ʱ
    }

    private void Update()
    {
        if(isInvincible)//�����޵�״̬ʱ
        {
            invincibleTimer -= Time.deltaTime;//���е���ʱ
            if(invincibleTimer<=0)//����ʱ������
            {
                isInvincible = false;//ȡ���޵�״̬
            }
        }
    }
    public void DestoryCharacter()//���ٽ�ɫ����
    {
        currentHealth = maxHealth;//�ָ���Ѫ��
        gameObject.SetActive(false);
    }
}
