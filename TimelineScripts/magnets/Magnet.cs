using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {
    public Transform player;
    public float speed;
    private string year;

	// Use this for initialization
	void Start () {
        year = gameObject.transform.name.Split('_')[0];
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collector"))
        {

            collision.gameObject.GetComponentInParent<LessonController>().yearsToCheckCount--;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            this.enabled = false;
        }
    }

    public string Year {
        get { return year; }
    }

}
