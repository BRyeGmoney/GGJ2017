using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Villager : MonoBehaviour {

    public SpriteRenderer WordOne;
    public SpriteRenderer WordTwo;
    public SpriteRenderer WordThree;

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

        WordOne.sprite = Sprite.Create(curPuzzle.Hint1, new Rect(0,0, curPuzzle.Hint1.width, curPuzzle.Hint1.height), Vector2.zero);
        WordTwo.sprite = Sprite.Create(curPuzzle.Hint2, new Rect(0, 0, curPuzzle.Hint2.width, curPuzzle.Hint2.height), Vector2.zero);
        WordThree.sprite = Sprite.Create(curPuzzle.Hint3, new Rect(0, 0, curPuzzle.Hint3.width, curPuzzle.Hint3.height), Vector2.zero);
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

    public bool ComparePuzzle()
    {
        int[,] playerAnswer = CivilizationBehaviour.civInstance.playerAnswer;
        bool equal =
            playerAnswer.Rank == curPuzzle.Answer.Rank &&
            Enumerable.Range(0, playerAnswer.Rank).All(dimension => playerAnswer.GetLength(dimension) == curPuzzle.Answer.GetLength(dimension)) &&
            playerAnswer.Cast<int>().SequenceEqual(curPuzzle.Answer.Cast<int>());
        return equal;
        //return CivilizationBehaviour.civInstance.playerAnswer == curPuzzle.Answer;
    }
}

