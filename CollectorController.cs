using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision was detected");
        if (other.gameObject.CompareTag("NatureCollectable"))
        {
            other.gameObject.SetActive(false);
        }

        


        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            //if (other.attachedRigidbody)
            //{
            //    other.attachedRigidbody.useGravity = true;
            //}
        }

        //gameobject.setactive(false)
        //other.gameObject.CompareTag("Player")
        //Destroy(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {  
        

    }

}
