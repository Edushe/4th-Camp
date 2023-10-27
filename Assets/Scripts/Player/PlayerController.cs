using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
    //��ɫ�Ļ������ƣ��ƶ�����Ծ��������
{
    [Header("======= ��ɫ��� =======")]
    public Player_Input input;//������������
    public PhysicCheck check;//���������
    Rigidbody2D rb;//��ɫ�ĸ������
    Animator animator;//��ɫ�Ķ������������

    [Header("======= ��ɫ���� =======")]
    [Tooltip("��ɫ�Ƿ�ɱ�����")]
    public bool canControl = true;//��ɫ�Ƿ�ɱ����ƣ��磺����ʱ�޷����ƣ�
    [Tooltip("��ɫ���ƶ��ٶ�")]
    public float speed = 300;//��ɫ���ƶ��ٶȣ�Ĭ��ֵΪ300
    [Tooltip("��ɫ����Ծ����")]
    public float jumpForce = 16.5f;//��ɫ����Ծ���ȣ�Ĭ��Ϊ16.5
    [Tooltip("��ɫ�����˱���������")]
    public float hurtBounceForce = 16.5f;//��ɫ�����˱��������ȣ�Ĭ��Ϊ16.5

    private void Awake()
    {
        input = GetComponent<Player_Input>();//��ȡ��ɫ���ϵİ�����������
        check = GetComponent<PhysicCheck>();//��ȡ��ɫ���ϵ����������
        rb = GetComponent<Rigidbody2D>();//��ȡ��ɫ���ϵĸ������
        animator = GetComponent<Animator>();//��ȡ��ɫ���ϵĶ������������
    }

    int moveForward = -1;//�ƶ�����
    private void Update()
    {
        UIManager.Instance.currentHealth = GetComponent<Character>().currentHealth;
        UIManager.Instance.maxHealth = GetComponent<Character>().maxHealth;
        //ͬ����ǰѪ����UI��ʾ

        animator.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        //�������������е�"velocityX"��������Ϊ��ɫ����ĺ����ٶȵľ���ֵ�������ƶ�ʱ�ٶ�Ϊ������
        animator.SetFloat("velocityY", rb.velocity.y);
        //�������������е�"velocityY"��������Ϊ��ɫ����������ٶ�
        animator.SetBool("isGround", check.isGround);
        //�������������е�"isGround"��������Ϊ�������е�isGround״̬

        if (Input.GetKey(input.keyLeft)) moveForward = -1;
        //����������е�"���ƶ���"������ʱ�������ƶ�����Ϊ-1
        else if (Input.GetKey(input.keyRight)) moveForward = 1;
        //����������е�"���ƶ���"������ʱ�������ƶ�����Ϊ1
        else moveForward = 0;//�����ƶ��������

        if (Input.GetKeyDown(input.keyJump) && check.isGround) Jump();//������Ծ������λ�ڵ���ʱ,������Ծ

        if (Input.GetKeyDown(input.keyAttack)) PlayerAttack();//���¹�����ʱ�����й���
    }

    private void FixedUpdate()
    {
        if (canControl == false) return;//�޷�������ʱ����ִ�к�������
        Move();
    }

    #region ��ɫ���ƶ�����
    public void Move()
    {
        switch(moveForward)
        {
            case -1://�ƶ�����Ϊ-1ʱ
                transform.localScale = new Vector3(-1, 1, 1);//��ɫ������з�ת
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                //��ɫ����speed��С���ٶȽ����ƶ�
                break;

            case 1://�ƶ�����Ϊ1ʱ
                transform.localScale = new Vector3(1, 1, 1);//��ɫ���ҽ��з�ת
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                //��ɫ���Ұ�speed��С���ٶȽ����ƶ�
                break;

            case 0://�ƶ�����Ϊ0ʱ
                rb.velocity = new Vector2(0, rb.velocity.y);
                break;
        }
    }
    #endregion

    #region ��ɫ����Ծ����
    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        //�Խ�ɫ������Ϸ����ṩһ��jumpForce��С�������ṩ��ʽΪ˲ʱ
    }
    #endregion

    #region ��ɫ�������
    public void PlayerHurtAnimation()//��ɫ���˶���
    {
        animator.SetTrigger("hurt");//����Ҷ����������д���"hurt"
    }
    public void PlayerHurtEffect(Transform attacker)//��ɫ����Ч��
    {
        canControl = false;
        rb.velocity = Vector2.zero;//ʹ��ɫֹͣ�ƶ�
        rb.AddForce(new Vector2((transform.position.x - attacker.position.x), 0).normalized * hurtBounceForce, ForceMode2D.Impulse);
        //���ݽ�ɫ�빥���ߵ�ˮƽ���뷽���ṩһ��hurtBounceForce��С�������ṩ��ʽΪ˲ʱ
    }
    #endregion

    #region ��ɫ�������
    public void PlayerDeadAnimation()//��ɫ��������
    {
        //if(animator.GetBool("isDead")==false) animator.SetBool("isDead", true);//����Ҷ����������н�"isDead"����Ϊtrue
        animator.SetTrigger("isDead");
    }

    public void PlayerDeadEffect()
    {
        canControl = false;//��ɫ�޷�����������
        rb.velocity = Vector2.zero;//ʹ��ɫֹͣ�ƶ�
    }

    public void PlayerRespawn()
    {
        GetComponent<Character>().currentHealth = GetComponent<Character>().maxHealth;//����һ���Ѫ��
        transform.position = GameObject.Find("ReSpawnPoints").GetComponent<PlayerRespawn>().point.position;//������ҳ�����
        animator.ResetTrigger("isDead");//��������ź�

        for (int i=0;i<GameObject.Find("RefreshItem").transform.childCount;i++)//������RefreshItem�����������������
            GameObject.Find("RefreshItem").transform.GetChild(i).gameObject.SetActive(true);//����ȫ������
        for (int i = 0; i < GameObject.Find("RefreshEnemy").transform.childCount; i++)//������RefreshEnemy�����������������
            GameObject.Find("RefreshEnemy").transform.GetChild(i).gameObject.SetActive(true);//����ȫ������
        
        canControl = true;//��ɫ�ָ�����
    }
    #endregion

    #region ��ɫ�������
    public void PlayerAttack()
    {
        animator.SetTrigger("clickAttack");//����Ҷ����������д���"clickAttack"
        rb.velocity = new Vector2(0,rb.velocity.y);//ʹ��ɫˮƽ����ֹͣ�ƶ�
        canControl = false;
    }
    #endregion

}
