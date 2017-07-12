using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class ButtonClickEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{

    private GameObject[] buttons;


    private void ChangeButtonColor(string buttonName)
    {

        foreach (GameObject button in this.buttons)
        {
            if (button.name == buttonName)
            {
                button.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                button.GetComponent<Renderer>().material.color = new Color32(156, 32, 39, 255);
            }

        }

    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {

        if (vb.VirtualButtonName == "GoLeftVB")
        {
           
        }
        else if (vb.VirtualButtonName == "GoRightVB")
        {

        }

    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        foreach (GameObject button in this.buttons)
        {
            button.GetComponent<Renderer>().material.color = new Color32(156, 32, 39, 255);
        }

    }

    private void InitQuestions()
    {
        

    }

    private void InitBUttons()
    {
        this.buttons[0] = GameObject.Find("GoLeftCubeBtn");
        this.buttons[1] = GameObject.Find("GoRightCubeBtn");
    }

    // Use this for initialization
    void Start()
    {

        this.buttons = new GameObject[2];
        this.InitBUttons();

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
       
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }





    }

}


