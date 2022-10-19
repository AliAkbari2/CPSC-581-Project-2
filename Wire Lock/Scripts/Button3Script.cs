using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3Script : MonoBehaviour
{
    private Vector3 touchPos;
    public LayerMask colliderLayer;

    public static bool canRotate = true;

    [SerializeField] private float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            RaycastHit2D hit = Physics2D.Raycast(touchPos, gameObject.transform.position, .001f, colliderLayer);

            if (hit.collider != null)
            {
                if (hit.collider.transform.gameObject.name == gameObject.name && canRotate)
                {
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                    Socket5Script.isRotating = true;
                    Socket6Script.isRotating = true;
                }
            }
        }
        else
        {
            Socket5Script.isRotating = false;
            Socket6Script.isRotating = false;
        }
    }
}
