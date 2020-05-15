using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pigs;
    public List<GameObject> stars;
    public static GameManager instance;
    private Vector3 originPos;
    public GameObject win;
    public GameObject lose;
    private void Awake()
    {
        instance = this;
        if (birds.Count > 0) {
            originPos = birds[0].transform.position;
        }
    }

    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++) {
            if (i == 0)
            {
                birds[i].gameObject.transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }

    private void Start()
    {
        Initialized();
    }


    public void NextBird() {
        if (pigs.Count > 0) {
            if (birds.Count > 0){
                Initialized();
            }
            else {
                lose.SetActive(true);
            }
        } else {
            win.SetActive(true);
        }
    }

    public void ShowStars() {
        StartCoroutine("ShowStarsCoroutine");
    }

    IEnumerator ShowStarsCoroutine() {
        for (int i = 0; i < birds.Count + 1; i++)
        {
            yield return new WaitForSeconds(0.3f);
            stars[i].SetActive(true);
        }
    }
}
