using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CivilizationBehaviour : MonoBehaviour {

    public static CivilizationBehaviour civInstance;

    public PuzzleGeneration puzzleGen;
    public int curLevel;

    public GameObject SingleVillager;
    public GameObject Villagers;
    public GameObject Priest;

    public GameObject puzzleInteractionButtons;
    public GameObject puzzleQuestion;

    private Villager villager;

	// Use this for initialization
	void Start () {
        puzzleGen = new PuzzleGeneration();
        civInstance = this;

        DOTween.Init();

        Reset();

        NextPuzzle();
	}

    private void Reset()
    {
        curLevel = -1;
    }

    void NextPuzzle()
    {
        curLevel += 1;
        gameObject.GetComponent<Animator>().SetBool("NeedPuzzle", true);
    }

    public void MoveButtonsInView()
    {
        DOTween.To(() => puzzleInteractionButtons.transform.localPosition, y => puzzleInteractionButtons.transform.localPosition = y, new Vector3(0f, 125f, 0f), 1f).SetEase(Ease.InQuad);
        //puzzleInteractionButtons.transform.DOMoveY(125, 2f).SetEase(Ease.InCubic);
    }

    public void MoveButtonsOutOfView()
    {
        //puzzleInteractionButtons.transform.DOMoveY(0f, 0.5f).SetEase(Ease.InOutCubic);
        DOTween.To(() => puzzleInteractionButtons.transform.localPosition, y => puzzleInteractionButtons.transform.localPosition = y, new Vector3(0f,-65f, 0f), 1f).SetEase(Ease.OutQuad);
    }

    public void ShowPuzzle()
    {
        puzzleQuestion.SetActive(true);
    }

    public void HidePuzzle()
    {
        puzzleQuestion.SetActive(false);
    }

    public void SubmitSolution(int solution)//change solution to actually be a grid to compare against
    {
        Animator villageAnimator = SingleVillager.GetComponent<Animator>();

        if (!villageAnimator.GetBool("answerSubmitted")) //replace with a local, quick to retrieve variable
        {
            MoveButtonsOutOfView();
            HidePuzzle();
            
            villageAnimator.SetInteger("Decision", solution);
            villageAnimator.SetBool("answerSubmitted", true);
        }
    }
}
