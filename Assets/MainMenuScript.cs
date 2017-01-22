using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public GameObject[] towersToChoose;
    private int towerChoiceIndex = 0;
    private GameObject rotatingTower;

	// Use this for initialization
	void Start () {
        rotatingTower = towersToChoose[towerChoiceIndex];
        rotatingTower.SetActive(true);
	}

    public void ChooseRightTower()
    {
        rotatingTower.SetActive(false);

        towerChoiceIndex += 1;
        if (towerChoiceIndex >= towersToChoose.Length)
        {
            towerChoiceIndex = 0;
        }

        rotatingTower = towersToChoose[towerChoiceIndex];
        rotatingTower.SetActive(true);
    }

    public void ChooseLeftTower()
    {
        rotatingTower.SetActive(false);

        towerChoiceIndex -= 1;
        if (towerChoiceIndex < 0)
        {
            towerChoiceIndex = towersToChoose.Length - 1;
        }

        rotatingTower = towersToChoose[towerChoiceIndex];
        rotatingTower.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
        rotatingTower.transform.Rotate(new Vector3(0f, 1f, 0f));
	}
}
