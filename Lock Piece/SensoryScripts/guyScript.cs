using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guyScript : MonoBehaviour
{
    Rigidbody2D rb;
    float dirx;
    float diry;
    [SerializeField]
    float moveSpeed = 300f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.acceleration.x * moveSpeed;
        diry = Input.acceleration.y * moveSpeed;

        //transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -20f, 100f));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirx, diry);
    }
}
