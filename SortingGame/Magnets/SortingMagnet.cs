using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingMagnet : MonoBehaviour {

    public Transform target;
    public float speed;
    public string mark;
    public bool isChecked = false;

    // Use this for initialization
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<ResizeObjectScript>().IsShrinking = true;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag.Contains("Collectable"))
        //{

        //    //collision.gameObject.GetComponentInParent<LessonController>().yearsToCheckCount--;
        //    //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        //    //this.enabled = false;
        //}
    }

    public string Mark {
        get {
            return mark;
        }
        
    }

    public bool IsChecked {
        get {
            return isChecked;
        }

        set 
        {
            isChecked = value;
        }
            
    }



}
