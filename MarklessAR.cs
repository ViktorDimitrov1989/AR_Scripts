using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarklessAR : MonoBehaviour {

    //Gyro
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rotation;

    //Cam
    private WebCamTexture cam;
    public RawImage background;
    public AspectRatioFitter fit;

    private bool arReady = false;


	// Use this for initialization
	void Start () {
        //Check if we support both services
        //Gyro
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("The device does not have gyroscope");
            return;
        }

        //Back camera
        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            if (!WebCamTexture.devices[i].isFrontFacing)
            {
                new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
        }


        //if we did not find back camera
        if (cam == null)
        {
            Debug.Log("The device does not have back camera");
            return;
        }


        //Both services are suppoorted - enable them
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyro = Input.gyro;
        gyro.enabled = true;

        cameraContainer.transform.rotation = Quaternion.Euler(90f, 0, 0);
        rotation = new Quaternion(0, 0, 1, 0);

        cam.Play();
        background.texture = cam;

        arReady = true;


	}
	
	// Update is called once per frame
	void Update () {
        if (arReady)
        {
            //update the camera
            float ratio = (float)cam.width / (float)cam.height;
            fit.aspectRatio = ratio;

            float scaleY = cam.videoVerticallyMirrored ? -1.0f : 1.0f;

            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orientation = -cam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0,0,orientation);

            //update gyroscope
            transform.localRotation = gyro.attitude * rotation;
        }
	}
}
