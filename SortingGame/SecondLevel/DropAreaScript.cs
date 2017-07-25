using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAreaScript : MonoBehaviour {
    public string mark;
    public GameObject scoreController;

    private bool isSelected;
    private Color baseColor;
    public List<GameObject> collectedObjects;

	// Use this for initialization
	void Start () {
        baseColor = gameObject.GetComponent<Renderer>().material.color;
        collectedObjects = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
   
        if (isSelected)
        {
            SelectObject();
        }
        else
        {
            DeselectObject();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        this.collectedObjects.Add(other.gameObject);
        scoreController.GetComponent<ScoreControllerScript>().IncreasePoints();
    }


    private void OnTriggerExit(Collider other)
    {
        this.collectedObjects.Remove(other.gameObject);
        scoreController.GetComponent<ScoreControllerScript>().DecreasePoints();
    }


    private void SelectObject()
    {
        Color color = new Color(1f, 1f, 0.076f);
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    private void DeselectObject()
    {
        gameObject.GetComponent<Renderer>().material.color = baseColor;
    }

    public bool IsSelected
    {
        get { return isSelected; }
        set { isSelected = value; }
    }

    public string Mark {
        get { return mark; }
    }

    public List<GameObject> CollectedObjects {
        get { return collectedObjects; } 
    }

    public void AddCollectableObject(GameObject obj)
    {
        collectedObjects.Add(obj);
    }


}
