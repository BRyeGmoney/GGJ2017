using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WrongAnswerWindowState : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        TowerBehaviour.towerInstance.OpenWrongWindows();
	}
}
