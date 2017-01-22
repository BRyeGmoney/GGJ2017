using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerWalkBackState : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("answerSubmitted", false);

        CivilizationBehaviour.civInstance.SingleVillager.GetComponent<Villager>().MoveBack(animator);
    }
}
