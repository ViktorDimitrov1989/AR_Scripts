using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureCollectorScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NatureCollectable"))
        {
            //make objects collide themselves when in the container
            int myLayer = 11;
            other.gameObject.layer = myLayer;
            Physics.IgnoreLayerCollision(myLayer, myLayer, false);

            //stop the gravity of collected object

        }
        else
        {

            Rigidbody rigi = other.gameObject.GetComponent<Rigidbody>();

            //Freeze object
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //Reset rotation
            other.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);

            //Change postition if the object(add force)
            rigi.velocity = Vector3.zero;

            //add force up
            rigi.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);

   
        }

    }

    private void Start()
    {
 
    }


}
