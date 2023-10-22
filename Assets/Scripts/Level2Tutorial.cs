using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Tutorial : MonoBehaviour
{
    public GameObject takeTheKey;
    public GameObject unlockDoor;
    public GameObject tutorialKey;
    private bool isDoorOpen=false;


    private void Start()
    {
        StartCoroutine(Level2TutorialCoroutine());
    }

    IEnumerator Level2TutorialCoroutine()
    {

        while (true) 
        {
            if (tutorialKey.activeInHierarchy)
            {
                takeTheKey.SetActive(true);
                unlockDoor.SetActive(false);

                yield return null;

            }
            else
            {
                    
                takeTheKey.SetActive(false);
                if(!isDoorOpen) 
                    unlockDoor.SetActive(true);

                yield return null;
            }
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDoorOpen = true;
            unlockDoor.SetActive(false);
        } 
    }
}
