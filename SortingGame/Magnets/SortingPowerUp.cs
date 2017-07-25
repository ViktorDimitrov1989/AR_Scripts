using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingPowerUp : MonoBehaviour {
    public GameObject bottomQuad;
    public string target;
    public GameObject scoreController;

    private Vector3 lastPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SortingMagnet>().Mark.Equals(target))
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //enable the magnet script
            other.GetComponent<SortingMagnet>().enabled = true;
            //set the object to which will be atracted
            other.GetComponent<SortingMagnet>().target = bottomQuad.transform;
            //increase the score and prevent one object to be scored second time
            if (!other.gameObject.GetComponent<SortingMagnet>().isChecked)
            {
                StartCoroutine(scoreController.GetComponent<PointCounter>().ShowMessage("correct", other.GetComponent<SortingMagnet>().Mark));
                other.gameObject.GetComponent<SortingMagnet>().IsChecked = true;
            }

            //other.GetComponent<ResizeObjectScript>().IsShrinking = true;
        }
        else
        {
            StartCoroutine(scoreController.GetComponent<PointCounter>().ShowMessage("wrong", other.GetComponent<SortingMagnet>().Mark));
            other.GetComponent<MovingBackwardsScript>().StartDrift();
            other.GetComponent<SortingMagnet>().enabled = false;
            //other.GetComponent<ResizeObjectScript>().IsShrinking = true;
        }

    }

    public GameObject BotomQuad {
        get {return bottomQuad;}
    }

}
