using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerBehaviour : MonoBehaviour {

    public GameObject WrongWindows;
    public GameObject correctWindows; 

    public static TowerBehaviour towerInstance;

    public bool isDesertTower;
    public bool isAncientTower;
    public bool isGlassTower;

    public ParticleSystem water;
    public ParticleSystem locusts;

    // Use this for initialization
    void Start () {
        towerInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenWrongWindows()
    {
        if (isDesertTower)
        {
            //anim desert tower window
            DOTween.To(() => WrongWindows.transform.localPosition, x => WrongWindows.transform.localPosition = x, new Vector3(0f, 0.91f, 0f), 1f);
        }
        else if (isGlassTower)
        {
            //anim glass tower
        }
        else if (isAncientTower)
        {
            //anim ancient tower
        }

        locusts.Play();
    }

    public void CloseWrongWindows()
    {
        if (isDesertTower)
        {
            DOTween.To(() => WrongWindows.transform.localPosition, x => WrongWindows.transform.localPosition = x, new Vector3(0f, 0f, 0f), 1f);
        }
        else if (isGlassTower)
        {
            //anim glass tower
        }
        else if (isAncientTower)
        {
            //anim ancient tower
        }

        locusts.Stop();
    }

    public void OpenCorrectWindows()
    {
        if (isDesertTower)
        {
            //anim desert tower window
            DOTween.To(() => correctWindows.transform.localPosition, x => correctWindows.transform.localPosition = x, new Vector3(0f, 0.91f, 0f), 1f);
        }
        else if (isGlassTower)
        {
            //anim glass tower
        }
        else if (isAncientTower)
        {
            //anim ancient tower
        }
    }

    public void CloseCorrectWindows()
    {
        if (isDesertTower)
        {
            DOTween.To(() => correctWindows.transform.localPosition, x => correctWindows.transform.localPosition = x, new Vector3(0f, 0f, 0f), 1f);
        }
        else if (isGlassTower)
        {
            //anim glass tower
        }
        else if (isAncientTower)
        {
            //anim ancient tower
        }
    }
}
