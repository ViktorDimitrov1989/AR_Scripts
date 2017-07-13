using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineMoving : MonoBehaviour {

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

            
            isTargetCollectable = target.CompareTag("Collectable");

            if (!isTargetCollectable)
            {
                Debug.Log("target is not collectable!!!");
                return;
            }

            infoText = target.GetComponentInChildren<TextMesh>().gameObject;
            
            //if !istargetCollectable -> return

            isMouseUp = false;
            isInfoTextShown = true;

            if (target != null && isTargetCollectable)
            {
                isMouseDrag = true;
                //Convert world position to screen position.
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            isInfoTextShown = false;
            isMouseUp = true;
            isMouseDrag = false;
        }
        if (isMouseDrag && isTargetCollectable)
        {

            isInfoTextShown = true;
            //track mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            //convert screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
            //It will update target gameobject's current postion.
            target.transform.position = currentPosition;
        }

        if (target != null)
        {
            if (!isInfoTextShown)
            {
                Debug.Log("font is fifty!!");
                infoText.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                infoText.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

        }

        //manage grow and shrink of the obj
        if (isMouseDrag
            && Mathf.Abs(new Vector3(0.23f, 0.23f, 0.23f).x - target.transform.localScale.x) > 0.005
            && isTargetCollectable)
        {
            Grow(target);
        }

        if (isMouseUp
            && Mathf.Abs(new Vector3(0.09f, 0.09f, 0.09f).x - target.transform.localScale.x) > 0.005
            && isTargetCollectable)
        {
            Shrink(target);
        }
       
        

    }

    public GameObject InfoText {
        get { return infoText; }
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


    //grow and shrink objects on touch and drop
    void Grow(GameObject target)
    {
        startScale = target.transform.localScale;
        endScale = new Vector3(0.23f, 0.23f, 0.23f);

        target.transform.localScale = Vector3.Lerp(startScale, endScale, 3.0f * Time.deltaTime);

        if (Mathf.Abs(endScale.x - target.transform.localScale.x) < 0.005)
        {
            Debug.Log("Grow ends");
            target.transform.localScale = endScale;
        }

    }

    void Shrink(GameObject target)
    {
        Vector3 st = target.transform.localScale;
        endScale = new Vector3(0.09f, 0.09f, 0.09f);

        target.transform.localScale = Vector3.Lerp(st, endScale, 2.0f * Time.deltaTime);

        if (Mathf.Abs(endScale.x - target.transform.localScale.x) < 0.005)
        {
            Debug.Log("Shrink ends");
            target.transform.localScale = endScale;
        }

    }
}
