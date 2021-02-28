using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange: MonoBehaviour
{
    private bool thirdPersonMode;
    private bool backwardMode;
    private bool lookLeft;
    private bool lookRight;
    private float targetRotation;


    public GameObject thirdCam;
    public GameObject firstCam;
    public GameObject backCam;
    public int camMode = 0;
    public int backMode = 0;
    private void Start()
    {
        thirdCam.SetActive(false);
        firstCam.SetActive(true);
        backCam.SetActive(false);
    }
 

    void Update()
    {
       /* lookLeft = Input.GetKey(KeyCode.Keypad4);
        lookRight = Input.GetKey(KeyCode.Keypad6);
       */

        thirdPersonMode = Input.GetButtonDown("Camera");
        backwardMode = Input.GetButtonDown("Backward");
        if (thirdPersonMode)
        {
            if (camMode == 0)
                camMode = 1;
            else
                camMode = 0;
            StartCoroutine(CamChange());
        }

        if(backwardMode)
        {
            if (backMode == 0)
                backMode = 1;
            else
                backMode = 0;
            StartCoroutine(CamChangeBack());
        }
    }
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(camMode == 0)
        {
            thirdCam.SetActive(false);
            firstCam.SetActive(true);
            backCam.SetActive(false);
        }
        if (camMode == 1)
        {
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
            backCam.SetActive(false);
        }
    }
    IEnumerator CamChangeBack()
    {
        yield return new WaitForSeconds(0.01f);
        if (backMode == 0)
        {
            backCam.SetActive(false);
            firstCam.SetActive(true);
            thirdCam.SetActive(false);
        }
        if (backMode == 1)
        {
            backCam.SetActive(true);
            firstCam.SetActive(false);
            thirdCam.SetActive(false);
        }    
    }


}
