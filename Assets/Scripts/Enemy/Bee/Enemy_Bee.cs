using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bee : EnemyGeneral
{
    public override void Move()//�۷���ƶ�Ч��
    {
        if(canMove)
        rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);
    }

    private void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);
        if (check.isTouchTop || check.isGround)//�Ӵ����컨���ذ�ʱ
            speed=-speed;//���з���ȡ��
    }

    public override void Hurt(Transform attacker)//�۷������Ч��
    {
        base.Hurt(attacker);
        canMove = false;//ȡ���ж�״̬
        StartCoroutine(hurtMove(attacker));
    }
    IEnumerator hurtMove(Transform attacker)
    {
        rb.velocity = Vector2.zero;//�޷��ƶ�
        yield return new WaitForSeconds(0.4f);//���0.4s��
        canMove = true;//�ָ��ж�״̬
    }
}
