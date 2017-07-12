using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwardsToStartPoint : MonoBehaviour
{
    Vector3 startPostion;
    Vector3 driftPosition;
    Quaternion startRotation;
    Quaternion driftRotation;


    public float driftSeconds = 3f;
    private float driftTimer = 0;
    private bool isDrifting = false;

    // Use this for initialization
    void Start()
    {
        startPostion = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            StartDrift();
        }
        
  
        if (isDrifting)
        {
            driftTimer += Time.deltaTime;
            if (driftTimer > driftSeconds)
            {
                SetInfoActive(gameObject.transform.Find("info").gameObject);
                stopDrift();
            }
            else
            {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(driftPosition, startPostion, ratio);
                transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);

                //TODO make object go to the end position when at the end!!!!!
            }

        }
    }

    private void SetInfoActive(GameObject info)
    {
        //If the child was found.
        if (info != null)
        {
            info.SetActive(true);
        }
    }

    private void StartDrift()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
 
        }
    }

}
