using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtAnimation : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerController>().canControl = true;
        //�������������ʱ����PlayerController��canControl״̬����Ϊture
    }
}
