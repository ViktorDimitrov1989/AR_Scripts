using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public string year;

    private List<GameObject> yearsToCheck;
    private Vector3 lastPosition;


    public bool collect = true;
	// Use this for initialization
	void Start () {
        this.yearsToCheck = new List<GameObject>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {

            //enable the MAgnet script
            other.GetComponent<Magnet>().enabled = true;

            //set the object to which will be atracted
            other.GetComponent<Magnet>().player = this.transform;

            //add year object to yearsToCheck
            this.yearsToCheck.Add(other.gameObject);


            //set the other(year object) mesh renderer.enabled to false when triggers

            //Finds and assigns the child of the player named "Gun".
            SetInfoInactive(other.transform.Find("info").gameObject);

     
        }
    }

    private void SetInfoInactive(GameObject info)
    {
        //If the child was found.
        if (info != null)
        {
            info.SetActive(false);
        }
    }

    public List<GameObject> getYearsToCheck()
    {
        return this.yearsToCheck;
    }

   
}
