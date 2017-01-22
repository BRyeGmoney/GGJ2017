using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Villager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.LookAt(Camera.main.transform);
	}

    public void GeneratePuzzle()
    {
        int[,] curPuzzle = CivilizationBehaviour.civInstance.puzzleGen.GenerateAPuzzle(CivilizationBehaviour.civInstance.curLevel);

        //display curPuzzle
    }

    public void MoveToTower(Animator animator)
    {
        //gameObject.transform.localPosition = new Vector3(-28.5f, 0.6f, 24.2f);
        //VillagerDoneMoving(animator);
        //gameObject.transform.DOMove(new Vector3(-28.5f, 6.6f, 24.2f), 1.5f).OnComplete(() => VillagerDoneMoving(animator));
        DOTween.To(() => transform.localPosition, x => transform.localPosition = x, new Vector3(35.7f, 0.6f, 4.43f), 1).OnComplete(() => VillagerDoneMoving(animator));
    }

    public void MoveBack(Animator animator)
    {
        DOTween.To(() => transform.localPosition, x => transform.localPosition = x, new Vector3(-4.3f, 0.6f, 4.43f), 1).OnComplete(() => VillagerDoneMoving(animator));
    }

    private void VillagerDoneMoving(Animator animator)
    {
        animator.SetTrigger("doneWalking");
    }
}

