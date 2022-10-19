using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasswordConfirmingScript : MonoBehaviour
{
    public GameObject usualGreen;
    public GameObject pressedGreen;
    public GameObject redGO;

    Vector3 touchPos;

    public LayerMask colliderLayer;

    // Start is called before the first frame update
    void Start()
    {
        usualGreen.SetActive(true);
        pressedGreen.SetActive(false);
        redGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            RaycastHit2D hit1 = Physics2D.Raycast(touchPos, transform.position, 1f, colliderLayer);

            if (hit1.collider != null)
            {
                if (Socket8Script.thePassword == "s6s1s2s7")
                {
                    usualGreen.SetActive(false);
                    pressedGreen.SetActive(true);
                    redGO.SetActive(false);

                    Invoke("changeTheScene", 2f);
                }
                else
                {
                    usualGreen.SetActive(false);
                    pressedGreen.SetActive(false);
                    redGO.SetActive(true);

                    Invoke("redExitMethod", 2f);
                }
            }
        }
        
    }

    void changeTheScene()
    {
        SceneManager.LoadScene("UnlockedScreen");
    }

    void redExitMethod()
    {
        usualGreen.SetActive(true);
        pressedGreen.SetActive(false);
        redGO.SetActive(false);

        Socket8Script.thePassword = "";

        Button1Script.canRotate = true;

        Socket1Script.lr.positionCount = 0;
        Socket1Script.startConnecting = true;
        Socket1Script.reachedNode = false;
        Socket1Script.startedDrag = false;

        Socket2Script.lr.positionCount = 0;
        Socket2Script.startConnecting = true;
        Socket2Script.reachedNode = false;
        Socket2Script.startedDrag = false;


        Button2Script.canRotate = true;

        Socket3Script.lr.positionCount = 0;
        Socket3Script.startConnecting = true;
        Socket3Script.reachedNode = false;
        Socket3Script.startedDrag = false;

        Socket4Script.lr.positionCount = 0;
        Socket4Script.startConnecting = true;
        Socket4Script.reachedNode = false;
        Socket4Script.startedDrag = false;


        Button3Script.canRotate = true;

        Socket5Script.lr.positionCount = 0;
        Socket5Script.startConnecting = true;
        Socket5Script.reachedNode = false;
        Socket5Script.startedDrag = false;

        Socket6Script.lr.positionCount = 0;
        Socket6Script.startConnecting = true;
        Socket6Script.reachedNode = false;
        Socket6Script.startedDrag = false;


        Button4Script.canRotate = true;

        Socket7Script.lr.positionCount = 0;
        Socket7Script.startConnecting = true;
        Socket7Script.reachedNode = false;
        Socket7Script.startedDrag = false;

        Socket8Script.lr.positionCount = 0;
        Socket8Script.startConnecting = true;
        Socket8Script.reachedNode = false;
        Socket8Script.startedDrag = false;
    }
}
