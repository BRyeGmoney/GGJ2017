using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Villager : MonoBehaviour {

    public GameObject WordOne;
    public GameObject WordTwo;
    public GameObject WordThree;

    private Puzzle curPuzzle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.LookAt(Camera.main.transform);
	}

    public void GeneratePuzzle()
    {
        curPuzzle = CivilizationBehaviour.civInstance.puzzleGen.GenerateAPuzzle(CivilizationBehaviour.civInstance.curLevel);

        WordOne.GetComponent<Renderer>().material.SetTexture("_MainTex", curPuzzle.Hint1);//.mainTexture = curPuzzle.Hint1;
        WordTwo.GetComponent<Renderer>().material.SetTexture("_MainTex", curPuzzle.Hint2);//.mainTexture = curPuzzle.Hint2;
        WordThree.GetComponent<Renderer>().material.SetTexture("_MainTex", curPuzzle.Hint3);//.mainTexture = curPuzzle.Hint3;
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
        DOTween.To(() => transform.localPosition, x => transform.localPosition = x, new Vector3(21.67f, 0.6f, 4.43f), 1).OnComplete(() => VillagerDoneMoving(animator));
    }

    private void VillagerDoneMoving(Animator animator)
    {
        animator.SetTrigger("doneWalking");
    }
}

