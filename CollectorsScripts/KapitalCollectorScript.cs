using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapitalCollectorScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KapitalCollectable"))
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

            rigi.velocity = Vector3.zero;
            rigi.angularVelocity = Vector3.zero;

            //Change postition if the object(add force)
            rigi.velocity = Vector3.zero;

            //Reset rotation
            other.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);

            //backwards
            rigi.AddForce(new Vector3(0, 2, 2), ForceMode.Impulse);
            //up
            rigi.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);

        }

    }
}
