using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
    float distance = 10;

    Vector3 startPostion;
    Vector3 driftPosition;
    Quaternion startRotation;
    Quaternion driftRotation;

    public float driftSeconds = 3f;
    private float driftTimer = 0;
    private bool isDrifting = false;
    private bool isInRightContainer = true;

    // Use this for initialization
    void Start()
    {
        startPostion = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isInRightContainer)
        {
            StartDrift();
        }

        if (isDrifting)
        {
            driftTimer += Time.deltaTime;
           
            if (driftTimer >= driftSeconds)
            {
                stopDrift();
            }
            else
            {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(driftPosition, startPostion, ratio);
                transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        ///compare tags of current object and the other object


        if (other.gameObject.CompareTag("KapitalCollector"))
        {
            isInRightContainer = true;
        }
        else
        {
            isInRightContainer = false;
        }

    }

    private void StartDrift()
    {
        isDrifting = true;
        driftTimer = 0;

        driftPosition = transform.position;
        driftRotation = transform.rotation;


        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

    }

    private void stopDrift()
    {
        isDrifting = false;
        transform.position = startPostion;
        transform.rotation = startRotation;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        rb.useGravity = false;

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;

            //GetComponent<Collider>().isTrigger = true;      
        }
    }


    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPos;

    }
}