using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControllerScript : MonoBehaviour {

    private Vector3 screenPosition;
    private GameObject target;
    private Vector3 offset;
    private bool isMouseUp;
    private bool isMouseDrag;

    public GameObject magnetController;
    public GameObject scoreController;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (scoreController.GetComponent<ScoreControllerScript>().CurrentPoints == 12)
        {
             ShowWinLooseMessage();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);

            SelectDropArea(target);
            SelectObject(target);
            
            isMouseUp = false;
            isMouseDrag = true;
            //Convert world position to screen position.
            screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
            offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseUp = true;
            isMouseDrag = false;
        }
        if (isMouseDrag && target.CompareTag("Collectable"))
        {
            //track mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            //convert screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
            //It will update target gameobject's current postion.
            target.transform.position = currentPosition;
        }

        magnetController.GetComponent<MagnetController>().AtractToSelectedDropPoint();
        
    }


    private void ShowWinLooseMessage()
    {
        if (scoreController.GetComponent<ScoreControllerScript>().Checkresult())
        {
            StartCoroutine(scoreController.GetComponent<ScoreControllerScript>().ShowMessage("win"));
            
        }
        else
        {
            StartCoroutine(scoreController.GetComponent<ScoreControllerScript>().ShowMessage("loose"));
        }

        scoreController.GetComponent<ScoreControllerScript>().ResetPoints();
    }

    private void SelectDropArea(GameObject dropArea)
    {
        if (!dropArea.CompareTag("DropArea") || dropArea == null)
        {
            return;
        }


        foreach (DropAreaScript script in GameObject.FindObjectsOfType<DropAreaScript>())
        {
            script.IsSelected = false;
        }

        target.GetComponent<DropAreaScript>().IsSelected = true;
    }


    private void SelectObject(GameObject target)
    {
        if (!IsObjectClickable(target))
        {
            return;
        }

        if (target == null || !target.CompareTag("Collectable"))
        {
            return;
        }

        foreach (ObjectBehaviourScript item in GameObject.FindObjectsOfType<ObjectBehaviourScript>())
        {
            item.IsSelected = false;
        }

        target.GetComponent<ObjectBehaviourScript>().IsSelected = true;
    }

    private bool IsObjectClickable(GameObject target)
    {

        if (target == null)
        {
            return false;
        }

        if (!target.CompareTag("Collectable"))
        {
            return false;
        }

        return true;
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
