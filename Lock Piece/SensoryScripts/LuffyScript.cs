using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuffyScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprtrndr;
    [SerializeField] float moveSpeed = 20f;
    Animator anim;

    public static string thePasswordofScenes = "";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprtrndr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //InvokeRepeating("checkingInput", 0, 2f);
        InvokeRepeating("movementFunc", 0, 1f);
    }

    // Update is called once per frame
    void checkingInput()
    {
        Debug.Log("The input x: " + Input.acceleration.x);
        Debug.Log("The input y: " + Input.acceleration.y);
        Debug.Log("The input z: " + Input.acceleration.z);
    }

    void movementFunc()
    {
        if(Input.acceleration.z < -0.8f)
        {
            anim.SetBool("HorizontalRunBool", false);
            anim.SetBool("VerticalRunBool", true);
            sprtrndr.flipY = false;
            sprtrndr.flipX = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, 1) * moveSpeed);
        }
        else if(Input.acceleration.z > 0.8f)
        {
            anim.SetBool("HorizontalRunBool", false);
            anim.SetBool("VerticalRunBool", true);
            sprtrndr.flipY = true;
            sprtrndr.flipX = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, -1) * moveSpeed);
        }
        else if(Input.acceleration.x < -0.8f)
        {
            anim.SetBool("VerticalRunBool", false);
            anim.SetBool("HorizontalRunBool", true);
            sprtrndr.flipX = true;
            sprtrndr.flipY = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(-1, 0) * moveSpeed);
        }
        else if (Input.acceleration.x > 0.8f)
        {
            anim.SetBool("VerticalRunBool", false);
            anim.SetBool("HorizontalRunBool", true);
            sprtrndr.flipX = false;
            sprtrndr.flipY = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(1, 0) * moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "ExitLeft")
        {
            SceneManager.LoadScene("OnePieceFinalScene");
        }
        if (collision.name == "ExitRight")
        {
            SceneManager.LoadScene("OnePiece2");
            thePasswordofScenes += "1";
        }
        if (collision.name == "ExitDown")
        {
            SceneManager.LoadScene("OnePiece3");
            thePasswordofScenes += "2";
        }
        if(collision.name == "ExitRightScene3")
        {
            SceneManager.LoadScene("OnePiece4");
            thePasswordofScenes += "3";
        }
        if (collision.name == "ExitUpScene4")
        {
            SceneManager.LoadScene("OnePieceFinalScene");
            thePasswordofScenes += "4";
        }
    }
}
