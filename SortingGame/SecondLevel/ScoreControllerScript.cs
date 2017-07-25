using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControllerScript : MonoBehaviour {
    public Text wrongAnswerText;
    public Text correctAnswerText;

    private int maxPoints;
    private int currentPoints;

	// Use this for initialization
	void Start () {
        maxPoints = 12;
	}

    public bool Checkresult()
    {
        DropAreaScript[] dropAreas = GameObject.FindObjectsOfType<DropAreaScript>();

        foreach (DropAreaScript item in dropAreas)
        {
            foreach (GameObject collectable in item.CollectedObjects)
            {
                if (item.Mark != collectable.GetComponent<ObjectBehaviourScript>().Mark)
                {

                    return false;
                }
            }
        }

        return true;
    }


    public IEnumerator ShowMessage(string type)
    {
        int delay = 2;

        switch (type)
        {
            case "win":
                correctAnswerText.text = "Браво!";
                yield return new WaitForSeconds(delay);
                correctAnswerText.text = "";
                break;
            case "lоose":
                wrongAnswerText.text = "Грешна подредба, опитай пак!";
                yield return new WaitForSeconds(delay);
                wrongAnswerText.text = "";
                break;
            default:
                break;
        }

    }

    public void ResetPoints()
    {
        currentPoints = 0;

    }


    public void IncreasePoints()
    {
        currentPoints += 1;
    }

    public void DecreasePoints()
    {
        currentPoints -= 1;
    }

    public int CurrentPoints {
        get { return currentPoints; }
    }



}
