using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterAttack : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //������������ʱ
        animator.ResetTrigger("clickAttack");//��������ź�
        animator.GetComponent<PlayerController>().canControl = true;//��PlayerController��canControl״̬����Ϊture
    }
}
