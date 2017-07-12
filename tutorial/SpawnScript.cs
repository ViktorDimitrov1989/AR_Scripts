using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnScript : MonoBehaviour
{
    private bool mPositionSet;

    // Define the position if the object
    // according to ARCamera position
    private bool SetPosition()
    {
        // get the camera position
        Transform cam = Camera.main.transform;

        // set the position 10 units forward from the camera position
        transform.position = cam.forward * 10;
        return true;
    }

    void Start()
    {
        // Defining the Spawning Position
        StartCoroutine(ChangePosition());
    }

    // We'll use a Coroutine to give a little
    // delay before setting the position
    private IEnumerator ChangePosition()
    {
        yield return new WaitForSeconds(0.2f);
        // Define the Spawn position only once
        if (!mPositionSet)
        {
            // change the position only if Vuforia is active
            if (VuforiaBehaviour.Instance.enabled)
                SetPosition();

        }
    }
}
