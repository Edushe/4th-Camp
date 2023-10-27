using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicCheck : MonoBehaviour
{
    [Header("======= ��������� =======")]
    [Tooltip("������뾶")]
    public float checkRaduis=0.2f;//��ⷶΧ��Ĭ��Ϊ0.2
    [Tooltip("����ͼ��")]
    public LayerMask groundLayer;//����ͼ��
    [Tooltip("ǽ��ͼ��")]
    public LayerMask wallLayer;//����ͼ��

    [Header("======= ��ɫ��ǰ״̬ =======")]
    [Tooltip("��ɫĬ�ϳ���-1Ϊ��1Ϊ��")]
    public int baseDirection = 1;//��ɫĬ�ϳ���
    [Tooltip("��ɫ��ǰ�Ƿ��ڵ���")]
    public bool isGround;//��ɫ�Ƿ��ڵ���
    [Tooltip("��ɫ��ǰ�Ƿ񴦽Ӵ����컨��")]
    public bool isTouchTop;//��ɫ�Ƿ�Ӵ����컨��
    [Tooltip("��ɫ��ǰ�Ƿ�Ӵ���ǽ��")]
    public bool isTouchWall;//��ɫ�Ƿ�Ӵ���ǽ��

    private void Update()
    {
        CheckGround();//�������е�����
        CheckWall();//��������ǽ����
        CheckTop();
    }

    public void CheckGround()//����Ƿ�λ�ڵ���
    {
        isGround = Physics2D.OverlapCircle(transform.position, checkRaduis, groundLayer);
        //����isGround״̬Ϊ���Ե�ǰ��ɫλ�ã���checkRaduis�뾶��Χ�ڣ�����Ƿ���groundLayerͼ��
    }

    public void CheckTop()//����Ƿ�Ӵ����컨��
    {
        isTouchTop = Physics2D.OverlapCircle(new Vector2(transform.position.x,(transform.position.y + GetComponent<CapsuleCollider2D>().bounds.size.y)), checkRaduis, groundLayer);
        //����isTouchTop״̬Ϊ���Ե�ǰ��ɫλ��+��ײ��߶ȣ���checkRaduis�뾶��Χ�ڣ�����Ƿ���groundLayerͼ��
    }

    public void CheckWall()//����Ƿ�Ӵ���ǽ��
    {
        float offset = GetComponent<CapsuleCollider2D>().bounds.size.x;
        bool touchLeftWall = Physics2D.OverlapCircle( //���ǽ����
            new Vector2
            (
                transform.position.x - GetComponent<CapsuleCollider2D>().bounds.size.x / 2, //�Խ�ɫx��λ��+��ײ����һ��Ϊ��ʼ��x��
                transform.position.y + GetComponent<CapsuleCollider2D>().bounds.size.y / 2),//�Խ�ɫy��λ��+��ײ��߶�һ��Ϊ��ʼ��y��
                checkRaduis, //������checkRaduisΪ�뾶
                wallLayer//wallpaperΪĿ����ͼ�����ײ���
            );
        bool touchRightWall = Physics2D.OverlapCircle( //�Ҳ�ǽ����
            new Vector2
            (
                transform.position.x + GetComponent<CapsuleCollider2D>().bounds.size.x / 2, //�Խ�ɫx��λ��+��ײ����һ��Ϊ��ʼ��x��
                transform.position.y + GetComponent<CapsuleCollider2D>().bounds.size.y / 2),//�Խ�ɫy��λ��+��ײ��߶�һ��Ϊ��ʼ��y��
                checkRaduis, //������checkRaduisΪ�뾶
                wallLayer//wallpaperΪĿ����ͼ�����ײ���
            );
        isTouchWall = (touchLeftWall&&baseDirection*transform.localScale.x<0) || (touchRightWall&& baseDirection * transform.localScale.x>0);
        //�����Ҳ�Ӵ���ǽ��ʱ���ҳ���ͽӴ�������ͬʱ,����isTouchWallΪ��
    }

    private void OnDrawGizmosSelected()//�ڱ༭���ڻ��Ƴ���ײ�������
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x - GetComponent<CapsuleCollider2D>().bounds.size.x / 2,
                transform.position.y + GetComponent<CapsuleCollider2D>().bounds.size.y / 2), checkRaduis);
        Gizmos.DrawWireSphere(new Vector2(transform.position.x + GetComponent<CapsuleCollider2D>().bounds.size.x / 2,
                transform.position.y + GetComponent<CapsuleCollider2D>().bounds.size.y / 2), checkRaduis);
        //����ǽ�ڵļ��������ʾ

        Gizmos.DrawWireSphere(transform.position, checkRaduis);
        //����ļ��������ʾ

        Gizmos.DrawWireSphere(new Vector2(transform.position.x, (transform.position.y + GetComponent<CapsuleCollider2D>().bounds.size.y)), checkRaduis);
        //�컨��ļ��������ʾ
    }
}
