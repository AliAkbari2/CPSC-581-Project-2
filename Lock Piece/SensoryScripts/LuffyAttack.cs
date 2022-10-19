using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuffyAttack : MonoBehaviour
{
    public GameObject akainuGO;
    public GameObject luffyGO;
    public GameObject choppyGO;
    public GameObject sanjiGO;
    public GameObject kaidoGO;
    public GameObject shanksGO;
    public GameObject drakeGO;
    public GameObject kizaruGO;
    public GameObject zoroGO;

    private Animator luffyAnim;
    private Animator akainuAnim;
    private static bool hasEntered = false;

    private int curCharacter = -1;
    public static bool shouldIComeBack = false;
    private string attacksPassword = "";

    // Start is called before the first frame update
    void Start()
    {
        Accelerometer.Instance.OnShake += LuffyAttacking;

        luffyAnim = luffyGO.GetComponent<Animator>();
        akainuAnim = akainuGO.GetComponent<Animator>();

        akainuGO.SetActive(false);
        choppyGO.SetActive(false);
        sanjiGO.SetActive(false);
        kaidoGO.SetActive(false);
        shanksGO.SetActive(false);
        drakeGO.SetActive(false);
        kizaruGO.SetActive(false);
        zoroGO.SetActive(false);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Accelerometer.Instance.OnShake -= LuffyAttacking;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CombatArea" && !hasEntered)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;

            transform.position = new Vector2(611, 290);
            hasEntered = true;
            //Destroy(GetComponent<LuffyScript>());
            luffyGO.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            akainuGO.SetActive(true);
            luffyAnim.SetBool("GearTwoStartBool", true);
            Invoke("HisGearTwoConst", 1f);
        }
    }

    private void Update()
    {
        if(hasEntered)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if(shouldIComeBack)
        {
            HisGearTwoConst();
            shouldIComeBack = false;
        }
    }

    public void HisGearTwoConst()
    {
        luffyGO.transform.localScale = new Vector3(1.546312f, 1.692437f, 0);
        transform.position = new Vector2(611, 290);

        luffyAnim.SetBool("GearTwoConstBool", true);
        luffyAnim.SetBool("GearTwoAttackBool", false);

        if(curCharacter == 0)
        {
            akainuGO.SetActive(false);
            choppyGO.SetActive(true);
            sanjiGO.SetActive(false);
            kaidoGO.SetActive(false);
            shanksGO.SetActive(false);
            drakeGO.SetActive(false);
            kizaruGO.SetActive(false);
            zoroGO.SetActive(false);
        }
        else if (curCharacter == 1)
        {
            akainuGO.SetActive(false);
            choppyGO.SetActive(false);
            sanjiGO.SetActive(true);
            kaidoGO.SetActive(false);
            shanksGO.SetActive(false);
            drakeGO.SetActive(false);
            kizaruGO.SetActive(false);
            zoroGO.SetActive(false);
        }
        else if (curCharacter == 2)
        {
            akainuGO.SetActive(false);
            choppyGO.SetActive(false);
            sanjiGO.SetActive(false);
            kaidoGO.SetActive(true);
            shanksGO.SetActive(false);
            drakeGO.SetActive(false);
            kizaruGO.SetActive(false);
            zoroGO.SetActive(false);
        }
        else if (curCharacter == 3)
        {
            akainuGO.SetActive(false);
            choppyGO.SetActive(false);
            sanjiGO.SetActive(false);
            kaidoGO.SetActive(false);
            shanksGO.SetActive(true);
            drakeGO.SetActive(false);
            kizaruGO.SetActive(false);
            zoroGO.SetActive(false);
        }
        else if (curCharacter == 4)
        {
            akainuGO.SetActive(false);
            choppyGO.SetActive(false);
            sanjiGO.SetActive(false);
            kaidoGO.SetActive(false);
            shanksGO.SetActive(false);
            drakeGO.SetActive(true);
            kizaruGO.SetActive(false);
            zoroGO.SetActive(false);
        }
        else if (curCharacter == 5)
        {
            akainuGO.SetActive(false);
            choppyGO.SetActive(false);
            sanjiGO.SetActive(false);
            kaidoGO.SetActive(false);
            shanksGO.SetActive(false);
            drakeGO.SetActive(false);
            kizaruGO.SetActive(true);
            zoroGO.SetActive(false);
        }
        else if (curCharacter == 6)
        {
            akainuGO.SetActive(false);
            choppyGO.SetActive(false);
            sanjiGO.SetActive(false);
            kaidoGO.SetActive(false);
            shanksGO.SetActive(false);
            drakeGO.SetActive(false);
            kizaruGO.SetActive(false);
            zoroGO.SetActive(true);
        }
        else if (curCharacter == 7)
        {
            akainuGO.SetActive(false);
            choppyGO.SetActive(false);
            sanjiGO.SetActive(false);
            kaidoGO.SetActive(false);
            shanksGO.SetActive(false);
            drakeGO.SetActive(false);
            kizaruGO.SetActive(false);
            zoroGO.SetActive(false);

            if(LuffyScript.thePasswordofScenes == "1234" && attacksPassword == "akski")
            {
                SceneManager.LoadScene("UnlockedScene");
                Destroy(this.gameObject);
            }
            else
            {
                LuffyScript.thePasswordofScenes = "";
                SceneManager.LoadScene("OnePiece1");
                hasEntered = false;
                Destroy(luffyGO);
            }
        }

        curCharacter++;
    }

    private void LuffyAttacking()
    {
        if(curCharacter == 0)
        {
            attacksPassword += "a";
        }
        else if(curCharacter == 1)
        {
            attacksPassword += "c";
            curCharacter--;
        }
        else if (curCharacter == 2)
        {
            attacksPassword += "s";
            curCharacter--;
        }
        else if (curCharacter == 3)
        {
            attacksPassword += "k";
        }
        else if (curCharacter == 4)
        {
            attacksPassword += "s";
        }
        else if (curCharacter == 5)
        {
            attacksPassword += "d";
        }
        else if (curCharacter == 6)
        {
            attacksPassword += "ki";
        }
        else if (curCharacter == 7)
        {
            attacksPassword += "z";
        }

        transform.position = new Vector2(615, 290);
        luffyGO.transform.localScale = new Vector3(4, 4, 0);
        luffyAnim.SetBool("GearTwoAttackBool", true);
        Invoke("HisGearTwoConst", 1f);
    }
}
