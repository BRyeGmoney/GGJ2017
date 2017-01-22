using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivVillagerState : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        GameObject villager = CivilizationBehaviour.civInstance.SingleVillager; //GameObject.FindGameObjectWithTag("SingleVillager");

        if (villager != null)
        {
            villager.SetActive(true);
            villager.GetComponent<Animator>().SetBool("startState", true);
        }
	}

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("villagerDone", false);
    }
}
