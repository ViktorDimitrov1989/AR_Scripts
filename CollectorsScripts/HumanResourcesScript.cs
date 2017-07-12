using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanResourcesScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HumanCollectable"))
        {
            //make objects collide themselves when in the container
            int myLayer = 11;
            other.gameObject.layer = myLayer;
            Physics.IgnoreLayerCollision(myLayer, myLayer, false);

            //stop the gravity of collected object
        }
        else
        {
            Rigidbody rigi = other.GetComponent<Rigidbody>();

            //Freeze object
            rigi.velocity = Vector3.zero;
            rigi.angularVelocity = Vector3.zero;

            //Reset rotation
            other.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);

            //Change postition to on of the respawn points
            rigi.AddForce(-transform.forward * 200);

           
            rigi.AddForce(new Vector3(3, 3, 0), ForceMode.Impulse);

        }

    }
}
