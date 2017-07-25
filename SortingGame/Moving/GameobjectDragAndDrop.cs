using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectDragAndDrop : MonoBehaviour {
    //text info or the object
    private GameObject infoText;

    private Vector3 screenPosition;
    private GameObject target;
    private Vector3 offset;

    //scale object variables
    private Vector3 startScale;
    private Vector3 endScale;

    private bool isMouseDrag;
    private bool isTargetCollectable = false;
    private bool isInfoTextShown = false;
    private bool isMouseUp = false;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);

            if (!IsTargetClickable(target))
            {
                return;
            }

            isMouseUp = false;
            isInfoTextShown = true;

            SelectAndGrowTarget(target);
            ShwoTargetInfo(target);
        }

    }

    private bool IsTargetClickable(GameObject target)
    {
        if (target == null)
        {
            return false;
        }

        isTargetCollectable = target.tag.Equals("Collectable");

        if (!isTargetCollectable)
        {
            return false;
        }

        foreach (ResizeObjectScript obj in GameObject.FindObjectsOfType<ResizeObjectScript>())
        {
            if (obj.IsGrowing || obj.IsShrinking)
            {
                return false;
            }
        }

        return true;
    }

    void SelectAndGrowTarget(GameObject target)
    {

        foreach (SelectObjectScript item in GameObject.FindObjectsOfType<SelectObjectScript>())
        {
            ResizeObjectScript resizeScript = item.gameObject.GetComponent<ResizeObjectScript>();

            item.IsSelected = false;
            resizeScript.IsShrinking = true;
        }

        target.GetComponent<ResizeObjectScript>().IsGrowing = true;
        target.GetComponent<SelectObjectScript>().IsSelected = true;

    }

    private void ShwoTargetInfo(GameObject target)
    {
        infoText = target.GetComponentInChildren<TextMesh>().gameObject;
        if (isInfoTextShown)
        {
            infoText.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            infoText.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }


    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

}
