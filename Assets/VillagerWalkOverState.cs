using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class VillagerWalkOverState : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("startState", false);

       CivilizationBehaviour.civInstance.SingleVillager.GetComponent<Villager>().MoveToTower(animator);
	}
}
