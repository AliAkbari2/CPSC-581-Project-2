using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket3Script : MonoBehaviour
{
    public static bool startConnecting = true;

    public static LineRenderer lr;

    private Vector3 touchPos;
    private Vector3 startPos;
    private Vector3 finalPos;
    Vector3[] positions;
    Vector3[] connectedPositions;
    public static bool startedDrag = false;
    public static bool reachedNode = false;
    private bool inTheRightGO = false;

    public LayerMask colliderLayer;

    public GameObject parentGO;
    public static bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startConnecting)
            ConnectTheWire();
    }

    void ConnectTheWire()
    {
        if (Input.touchCount > 0)
        {
            startPos = new Vector3(transform.position.x, transform.position.y, 0);
            //screentoworldpoint so that it actually translates my touch to the game properly.
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            positions = new Vector3[2] { startPos, new Vector3(touchPos.x, touchPos.y, 0) };

            //Detect if the finger touch is over a node. THIS DETECTS THE CURRENT POSITION OF THE FINGER
            RaycastHit2D hit1 = Physics2D.Raycast(touchPos, transform.position, 1f, colliderLayer);

            //If the finger is over a start node, start drawing. If the finger is over an end node, draw the final line.
            if (hit1.collider != null)
            {
                if (hit1.collider.transform.gameObject.name == gameObject.name)
                {
                    if (parentGO.transform.rotation.z > 90 && parentGO.transform.rotation.z < -90)
                    {
                        startedDrag = false;
                        inTheRightGO = false;
                    }
                    else
                    {
                        startedDrag = true;
                        inTheRightGO = true;
                    }
                }

                if (hit1.collider.transform.gameObject.layer == 3)
                {
                    if (inTheRightGO)
                    {
                        Button2Script.canRotate = false;
                        reachedNode = true;
                        finalPos = new Vector3(hit1.collider.transform.position.x, hit1.collider.transform.position.y, 0);
                        lr.positionCount = 2;
                        lr.numCapVertices = 10;
                        lr.SetPositions(new Vector3[2] { startPos, finalPos });
                        startConnecting = false;
                        Socket8Script.thePassword += "s3";
                    }
                }
            }


            //Draw the line using the line renderer, based on this.gameobject's position and finger touch.
            if ((!reachedNode) && (startedDrag) && (!isRotating))
            {
                lr.positionCount = 2;
                lr.numCapVertices = 10;
                lr.SetPositions(positions);
            }

            if ((Input.GetTouch(0).phase == TouchPhase.Ended) && !reachedNode)
            {
                startedDrag = false;
                inTheRightGO = false;
                lr.positionCount = 0;
            }
        }

    }
}
