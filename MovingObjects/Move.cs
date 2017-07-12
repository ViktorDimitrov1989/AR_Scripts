using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private Vector3 screenPosition;
    private bool isMouseDrag;
    private GameObject target;
    private Vector3 offset;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);

            //target.GetComponent<Rigidbody>().useGravity = true;
            target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

            if (target != null)
            {
                isMouseDrag = true;
                //Debug.Log("target position :" + target.transform.position);
                //Convert world position to screen position.
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (target.transform.position.z < -0.190f || target.transform.position.z > 0.230f )
            {
        
                target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.GetRandomNumber(-0.190f,0.230f));
            }
            isMouseDrag = false;
        }
        if (isMouseDrag)
        {
          
            //track mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            //convert screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
            //It will update target gameobject's current postion.
            
            target.transform.position = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z);



        }



    }

    public float GetRandomNumber(float minimum, float maximum)
    {
        System.Random random = new System.Random();

        var next = random.NextDouble();   

        return (float)(minimum + (next * (maximum - minimum)));
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
