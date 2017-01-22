using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswerState : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        CivilizationBehaviour.civInstance.puzzlePanel.SetActive(false);
        CivilizationBehaviour.civInstance.wrongAnswerUI.SetActive(true);
        CivilizationBehaviour.civInstance.towerFsm.SetTrigger("Wrong");
    }
}
