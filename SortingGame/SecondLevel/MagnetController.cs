
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagnetController : MonoBehaviour {
    public float speed;

    private GameObject selectedDropArea;
    private GameObject selectedObject;

    private List<GameObject> dropAreas;
    private List<GameObject> objects;


    // Use this for initialization
    void Start () {
        speed = 2f;
        dropAreas = new List<GameObject>();
        objects = new List<GameObject>();
        InitgameObjects();
    }

    private void InitgameObjects()
    {
        foreach (DropAreaScript script in GameObject.FindObjectsOfType<DropAreaScript>())
        {
            dropAreas.Add(script.gameObject);
        }


        foreach (ObjectBehaviourScript script in GameObject.FindObjectsOfType<ObjectBehaviourScript>())
        {
            objects.Add(script.gameObject);
        }
    }

    public void AtractToSelectedDropPoint()
    {

        if (IsHavingSelectedObjectAndDropArea())
        {
            selectedObject.transform.position =
            Vector3.MoveTowards(selectedObject.transform.position, selectedDropArea.transform.position, speed * Time.deltaTime);

            if (selectedObject.transform.position == selectedDropArea.transform.position)
            {
                selectedObject.GetComponent<ObjectBehaviourScript>().IsSelected = false;
                selectedDropArea.GetComponent<DropAreaScript>().IsSelected = false;
                selectedObject = null;
                selectedDropArea = null;
            }

        }
        else
        {
            Debug.Log("else1!!!!");
        }

    }

    public GameObject SelectedDropArea { get; set; }
    public GameObject SelectedObject { get; set; }

    private bool IsHavingSelectedObjectAndDropArea()
    {

        

        foreach (GameObject dropArea in dropAreas)
        {
            if (dropArea.GetComponent<DropAreaScript>().IsSelected)
            {
                selectedDropArea = dropArea;
            }
        }

        foreach (GameObject obj in objects)
        {
            if (obj.GetComponent<ObjectBehaviourScript>().IsSelected)
            {
                selectedObject = obj;
            }
        }

        if (selectedDropArea == null || selectedObject == null)
        {
            return false;
        }


        return true;

    }

    //private void DeselectGameObjects()
    //{
    //    foreach (GameObject dropArea in dropAreas)
    //    {
    //        dropArea.GetComponent<DropAreaScript>().IsSelected = false;
    //    }

    //    foreach (GameObject obj in objects)
    //    {
    //        obj.GetComponent<ObjectBehaviourScript>().IsSelected = false;
    //    }

    //}


}
