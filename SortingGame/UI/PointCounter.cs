using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    public Text humanPointsText;
    public Text naturePointsText;
    public Text kapitalPointsText;

    public Text wrongAnswerText;
    public Text correctAnswerText;
    public Text winText;

    private int humanPoints;
    private int naturePoints;
    private int kapitalPoints;


    private int humanMaxPoints;
    private int natureMaxPoints;
    private int kapitalMaxPoints;

    // Use this for initialization
    void Start () {
        humanPoints = 0;
        naturePoints = 0;
        kapitalPoints = 0;

        wrongAnswerText.text = "";
        correctAnswerText.text = "";
        winText.text = "";

        humanMaxPoints = 8;
        natureMaxPoints = 12;
        kapitalMaxPoints = 6;

        SetCountText(humanPoints, naturePoints, kapitalPoints);
    }

    public void IncreasePoints(int points, string type)
    {
        switch (type)
        {
            case "human":
                humanPoints += points;
                break;
            case "nature":
                naturePoints += points; 
                break;
            case "kapital": 
                kapitalPoints += points; 
                break;
            default:
                break;
        }

        SetCountText(humanPoints, naturePoints, kapitalPoints);

    }

    public IEnumerator ShowMessage(string type, string triggerObjectMark)
    {
        int delay = 2;

        IncreasePoints(1, triggerObjectMark);

        if (humanPoints == humanMaxPoints 
            && naturePoints == natureMaxPoints
            && kapitalPoints == kapitalMaxPoints)
        {
            type = "win";
        }

        switch (type)
        {
            case "correct":
                correctAnswerText.text = "Браво!";
                yield return new WaitForSeconds(delay);
                correctAnswerText.text = "";
                break;
            case "wrong":
                wrongAnswerText.text = "Грешка, опитай пак!";
                yield return new WaitForSeconds(delay);
                wrongAnswerText.text = "";
                break;
            case "win":
                winText.text = "Tи реши задачата!";
                yield return new WaitForSeconds(delay);
                winText.text = "";
                break;
            default:
                break;
        }


    }

    private void SetCountText(int humanPoints, int naturePoints, int kapitalPoints)
    {
        humanPointsText.text = string.Format("Човешки ресурси: {0}/{1}", humanPoints, humanMaxPoints);
        naturePointsText.text = string.Format("Природни ресурси: {0}/{1}", naturePoints, natureMaxPoints);
        kapitalPointsText.text = string.Format("Капиталови ресурси: {0}/{1}", kapitalPoints, kapitalMaxPoints);
    }


}
