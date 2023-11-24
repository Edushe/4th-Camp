using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneral : MonoBehaviour
    //���е��˵Ļ�������
{
    [Header("======= ������� =======")]
    public PhysicCheck check;//���������
    protected Rigidbody2D rb;//���˵ĸ��������ֻ�ɱ�������ʣ�
    protected Animator animator;//���˵Ķ��������������ֻ�ɱ�������ʣ�

    [Header("======= ���˻������� =======")]
    [Tooltip("���˵��ƶ��ٶ�")]
    public float speed = 100;//���˵��ƶ��ٶȣ�Ĭ��ֵΪ100
    [Tooltip("���˵���Ծ����")]
    public float jumpForce = 16.5f;//��ɫ����Ծ���ȣ�Ĭ��Ϊ16.5
    [Tooltip("���˵����˱���������")]
    public float hurtBounceForce = 16.5f;//��ɫ�����˱��������ȣ�Ĭ��Ϊ16.5

    [Header("======= ���˵ȴ���ʱ�� =======")]
    public bool canMove=true;//�Ƿ����ڵȴ�״̬
    public float waitTime;//�ȴ�ʱ��
    public float currentWaitTime;//��ǰ�ȴ�ʱ��

    private void Awake()
    {
        check = GetComponent<PhysicCheck>();//��ȡ�������ϵ����������
        rb = GetComponent<Rigidbody2D>();//��ȡ�������ϵĸ������
        animator = GetComponent<Animator>();//��ȡ�������ϵĶ������������
    }

    private void OnEnable()
    {
        canMove = true;//�ָ��ж�״̬
        gameObject.layer = 7;//�ָ�����ͼ��
        animator.SetBool("dead", false);//�ڵ��˵Ķ���������������"dead"Ϊfalse
    }

    private void Update()
    {
        Wait();//�ȴ�״̬���
    }

    private void FixedUpdate()
    {
        Move();//���г����ƶ�
    }

    public virtual void Move()//�ɱ���д���ƶ�����
    {
        if (canMove==false) return;//�ǿ��ƶ�״̬ʱ���������ƶ�

        rb.velocity = new Vector2(speed * -transform.localScale.x * Time.deltaTime, rb.velocity.y);
        //���˰�speed�ٶȳ���ǰ��������ƶ�
    }

    public virtual void Wait()//�ɱ���д�ĵȴ�״̬
    {
        if (currentWaitTime < waitTime)//δ����ȴ�ʱ��ʱ
        {
            canMove = false;//ȡ���ж�״̬
            rb.velocity = Vector2.zero;//��ɫֹͣ�ƶ�
            currentWaitTime += Time.deltaTime;//���е��˵ȴ���ʱ
        }
        else  //���ѵ���ȴ�ʱ��
        {
            currentWaitTime = 0; //�����õȴ���ʱ��
            canMove = true;//�ָ��ж�״̬
        }
    }

    public virtual void Hurt(Transform attacker) //�ɱ���д�ĵ��˵��ܻ�Ч��(���빥����)
    {
        animator.SetTrigger("hurt");//�ڵ��˵Ķ����������д���"hurt"
    }

    public virtual void Dead()//�ɱ���д�ĵ��˵�����Ч��
    {
        canMove = false;//ȡ���ж�״̬
        gameObject.layer = 2;//�ı����ͼ��
        animator.SetBool("dead", true);//�ڵ��˵Ķ���������������"dead"Ϊtrue
        rb.velocity = Vector2.zero;//����ֹͣ�ƶ�
    }

}
