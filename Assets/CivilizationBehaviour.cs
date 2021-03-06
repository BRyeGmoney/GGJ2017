﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public GameObject[] foliage;

    public int[,] playerAnswer;

    public GameObject correctAnswerUI;
    public GameObject wrongAnswerUI;
    public GameObject puzzlePanel;

    public Animator towerFsm;

    private Villager villager;

	// Use this for initialization
	void Start () {
        puzzleGen = new PuzzleGeneration();
        civInstance = this;

        DOTween.Init();

        Reset();

        NextPuzzle();

        FaceFoliage();
	}

    private void FaceFoliage()
    {
        foreach (GameObject thing in foliage)
        {
            thing.transform.LookAt(Camera.main.transform);
        }
    }

    private void Reset()
    {
        curLevel = -1;
    }

    void NextPuzzle()
    {
        playerAnswer = new int[,] { { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 } };
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
        //DOTween.defaultAutoPlay = AutoPlay.None;
        puzzleQuestion.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetId("show");
        DOTween.To(() => puzzleQuestion.transform.localPosition, x => puzzleQuestion.transform.localPosition = x, new Vector3(-20f, -54.1f, 0f), 0.5f).SetId("show");
        //puzzleQuestion.transform.DOMove(new Vector3(-20f, -54.1f, 0f), 0.5f).SetId("show");
        DOTween.Play("show");
        //puzzleQuestion.SetActive(true);

        //DOTween.defaultAutoPlay = AutoPlay.All;
    }

    public void HidePuzzle()
    {
        //DOTween.defaultAutoPlay = AutoPlay.None;
        puzzleQuestion.transform.DOScale(new Vector3(0, 0, 1), 0.2f).SetId("hide");
        DOTween.To(() => puzzleQuestion.transform.localPosition, x => puzzleQuestion.transform.localPosition = x, new Vector3(50f, -100f, 0f), 0.2f).SetId("hide");
        //puzzleQuestion.transform.DOMove(new Vector3(50f, -154f, 0f), 0.2f).SetId("hide");

        DOTween.Play("hide");
        //DOTween.defaultAutoPlay = AutoPlay.All;
        //puzzleQuestion.SetActive(false);
    }

    public void SubmitSolution()//change solution to actually be a grid to compare against
    {
        Animator villageAnimator = SingleVillager.GetComponent<Animator>();

        if (!villageAnimator.GetBool("answerSubmitted")) //replace with a local, quick to retrieve variable
        {
            MoveButtonsOutOfView();
            //HidePuzzle();
            
            //villageAnimator.SetInteger("Decision", solution);
            villageAnimator.SetBool("answerSubmitted", true);
        }
    }

    public void SetInput(Button pressedButton)
    {
        Image buttonImage = pressedButton.image;
        int buttonPressed = Int32.Parse(pressedButton.name);
        int toSetTo;

        if (buttonImage.color == Color.white)
        {
            buttonImage.color = Color.black;
            toSetTo = 0;
        }
        else
        {
            buttonImage.color = Color.white;
            toSetTo = 1;
        }

        switch(buttonPressed)
        {
            case 0:
                playerAnswer[0, 0] = toSetTo;
                break;
            case 1:
                playerAnswer[0, 1] = toSetTo;
                break;
            case 2:
                playerAnswer[1, 0] = toSetTo;
                break;
            case 3:
                playerAnswer[1, 1] = toSetTo;
                break;
            case 4:
                playerAnswer[2, 0] = toSetTo;
                break;
            case 5:
                playerAnswer[2, 1] = toSetTo;
                break;
            case 6:
                playerAnswer[3, 0] = toSetTo;
                break;
            case 7:
                playerAnswer[3, 1] = toSetTo;
                break;
            default:
                break;
        }
    }
}
