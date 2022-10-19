using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerTest : MonoBehaviour
{
    public GameObject cubeGO;
    public GameObject circleGO;

    bool isCircleActive= false;
    bool isCubeActive = true;

    // Start is called before the first frame update
    void Start()
    {
        Accelerometer.Instance.OnShake += ActionToRunWhenShakingDevice;
        circleGO = GameObject.FindGameObjectWithTag("Circle");
        cubeGO = GameObject.FindGameObjectWithTag("Square");

        circleGO.SetActive(false);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Accelerometer.Instance.OnShake -= ActionToRunWhenShakingDevice;
    }

    private void ActionToRunWhenShakingDevice()
    {
        if(isCircleActive == false)
        {
            circleGO.SetActive(true);
            isCircleActive = true;

            cubeGO.SetActive(false);
            isCubeActive = false;
        }
        else if(isCubeActive == false)
        {
            circleGO.SetActive(false);
            isCircleActive = false;

            cubeGO.SetActive(true);
            isCubeActive = true;
        }
    }
}
