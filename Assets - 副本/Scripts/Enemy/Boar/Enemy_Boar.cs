using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boar : EnemyGeneral
{
    public override void Move()//Ұ����ƶ�Ч��
    {
        base.Move();//��ִ�е��˻������еķ���
        animator.SetBool("chasing", false);
    }

    private void Update()
    {
        if (check.isTouchWall)//�Ӵ���ǽ��ʱ
            Wait();
    }
    public override void Wait()//Ұ��ĵȴ�Ч��
    {
        base.Wait();
        animator.SetBool("waiting", !canMove);//���õȴ�����
        if (canMove==true)//�����ж�ʱ
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);//��ɫ���з�ת
        }
    }

    public override void Hurt(Transform attacker)//Ұ�������Ч��
    {
        base.Hurt(attacker);
        canMove = false;//ȡ���ж�״̬
        StartCoroutine(hurtMove(attacker));
    }
    IEnumerator hurtMove(Transform attacker)
    {
        rb.AddForce(new Vector2((transform.position.x - attacker.position.x), 0).normalized * hurtBounceForce, ForceMode2D.Impulse);
        //���ݽ�ɫ�빥���ߵ�ˮƽ���뷽���ṩһ��hurtBounceForce��С�������ṩ��ʽΪ˲ʱ
        yield return new WaitForSeconds(0.3f);//���0.3s��
        canMove = true;//�ָ��ж�״̬
    }
}
