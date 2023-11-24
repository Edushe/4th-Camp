using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bee : EnemyGeneral
{
    public override void Move()//��д�۷���ƶ�Ч��
    {
        if (canMove == false) return;

        if ((check.isGround && speed < 0)||(check.isTouchTop&&speed>0)) speed = -speed;//�Ӵ���ǽ����컨��ʱ���ƶ�����ȡ��
        rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);//�����ƶ�
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
