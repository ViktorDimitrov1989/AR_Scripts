using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviourScript : MonoBehaviour {
    public float speed = 25;
    public string mark;

    private bool isSelected;
    private Color baseColor;
    private Color highlitedColor;
    private bool isRotate;

    // Use this for initialization
    void Start() {
        isRotate = true;
        baseColor = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update() {
        Rotate();
        ChangeObjectColor();
    }

    public bool IsSelected {
        get { return isSelected; }
        set { isSelected = value; }
    }

    private void ChangeObjectColor()
    {
        if (isSelected)
        {
            SelectObject();
        }
        else
        {
            DeselectObject();
        }
    }

    public string Mark {
        get { return mark; }
    }

    private void SelectObject()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color32(253, 253, 13, 1);
    }


    private void DeselectObject()
    {
        gameObject.GetComponent<Renderer>().material.color = baseColor;
    }


    private void Rotate()
    {
        if (isRotate)
        {

        }
        transform.Rotate(new Vector3(0,transform.position.y,0), speed * Time.deltaTime);
    }



}
