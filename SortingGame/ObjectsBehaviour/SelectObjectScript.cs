using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectScript : MonoBehaviour {
    public bool isSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (isSelected)
        //{
        //    gameObject.GetComponent<ResizeObjectScript>().IsGrowing = true;
        //}
        //else
        //{
        //    gameObject.GetComponent<ResizeObjectScript>().IsShrinking = true;
        //}
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;


        if (other.CompareTag("Collectable"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 150);
        }
    }

    public bool IsSelected {
        get { return isSelected; }
        set { isSelected = value; }
    }
}
