using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectDragAndDrop : MonoBehaviour {
    private Vector3 screenPosition;
    private bool isMouseDrag;
    private GameObject target;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {

        if (target != null)
        {
            Shrink(target);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);

            if (target.tag.Contains("Collector"))
            {
                return;
            }


            target.GetComponent<Rigidbody>().useGravity = true;

            //test
                Grow(target);
            //test

            

            if (target != null)
            {
                isMouseDrag = true;
                Debug.Log("target position :" + target.transform.position);
                //Convert world position to screen position.
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Shrink(target);
            isMouseDrag = false;
        }
        if (isMouseDrag)
        {

            Grow(target);
            //track mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            //convert screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
            //It will update target gameobject's current postion.
            target.transform.position = currentPosition;
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


    //grow and shrink objects on touch and drop
    void Grow(GameObject target)
    {
        Vector3 startScale = target.transform.localScale;
        Vector3 endScale = new Vector3(0.16f, 0.16f, 0.16f);

        target.transform.localScale = Vector3.Lerp(startScale, endScale, 3.0f * Time.deltaTime);

    }

    void Shrink(GameObject target)
    {
        Vector3 st = target.transform.localScale;
        Vector3 endScale = new Vector3(0.07f, 0.07f, 0.07f);

        target.transform.localScale = Vector3.Lerp(st, endScale, 2.0f * Time.deltaTime);
       
    }

}
