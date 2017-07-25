using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingBottomQuadBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Collectable"))
        {

            GameObject otherGO = other.gameObject;

            Debug.Log("magnet disabled !!!!!!!");
            otherGO.GetComponent<SortingMagnet>().enabled = false;
            other.GetComponent<Rigidbody>().useGravity = true;

            //make objects collide themselves when in the container
            int myLayer = 11;
            other.gameObject.layer = myLayer;
            Physics.IgnoreLayerCollision(myLayer, myLayer, false);
        }

    }

}
