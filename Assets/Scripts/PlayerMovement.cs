using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement PM;

    private float scaleControl = 1;
    private float speed = 6f;
    private float horiSpeed = 4f;
    [HideInInspector] public float gemCount;
    [HideInInspector] public float stickmanCount;

    //1=red 2=green 3=yellow
    private float colorInt = 0;

    //Metarials
    [SerializeField] private Material greenMat;
    [SerializeField] private Material yellowMat;
    [SerializeField] private Material redMat;

    //The player's color
    private string playerColor = "Yellow";

    private Rigidbody rb;
    private Animator anim;

    [SerializeField] private TMP_Text stickmanText;
    [SerializeField] private TMP_Text gemCountText;
    [SerializeField] private Camera cam;

    private void Awake()
    {
        PM = this;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {
        GetComponent<SkinnedMeshRenderer>().material = yellowMat;
    }

    // Update is called once per frame
    void Update()
    {
        Grow();
        LeftRightMovement();
        //Camera Position
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, this.transform.position.z - 7.5f);

        //Player always running to +z
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + (speed * Time.deltaTime));

      
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("isSlide", true);
        }
        else
        {
            anim.SetBool("isSlide", false);
        }

    }

    private void LeftRightMovement()
    {
        float hori = Input.GetAxisRaw("Horizontal");

        //left right movement
        rb.velocity = new Vector3(hori * horiSpeed, rb.velocity.y, rb.velocity.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        //take gem
        if (other.gameObject.tag == "Gem")
        {
            gemCount += 1;
            Destroy(other.gameObject);
            gemCountText.text = "" + gemCount;
        }

        //CHANGE COLOR
        if(other.gameObject.name == "RedWall")
        {
            GetComponent<SkinnedMeshRenderer>().material = redMat;
            playerColor = "Red";
        }
        else if (other.gameObject.name == "GreenWall")
        {
            GetComponent<SkinnedMeshRenderer>().material = greenMat;
            playerColor = "Green";
        }
        else if (other.gameObject.name == "YellowWall")
        {
            GetComponent<SkinnedMeshRenderer>().material = yellowMat;
            playerColor = "Yellow";
        }

        //Grow
        if(other.gameObject.tag == "YellowBots")
        {
            colorInt = 3;
            Destroy(other.gameObject);
            Debug.Log(colorInt);
        }
        else if(other.gameObject.tag == "GreenBots")
        {
            colorInt = 2;
            Destroy(other.gameObject);
            Debug.Log(colorInt);
        }
        else if (other.gameObject.tag == "RedBots")
        {
            colorInt = 1;
            Destroy(other.gameObject);
            Debug.Log(colorInt);
        }

    }


    private void Grow()
    {
        //IF OUR COLOR IS YELLOW
        if(playerColor == "Yellow")
        {
            if(colorInt == 3)
            {
                scaleControl += 0.1f;
                stickmanCount += 1;
                if(scaleControl < 3)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
                }
                colorInt = 0;
                
            }
            else if(colorInt == 2)
            {
                if(stickmanCount > 0)
                {
                    stickmanCount -= 1;
                }
                if(scaleControl > 1)
                {
                    scaleControl -= 0.1f;
                    transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
                }
                colorInt = 0;

            }
            else if(colorInt == 1)
            {
                if (stickmanCount > 0)
                {
                    stickmanCount -= 1;
                }
                if (scaleControl > 1)
                {
                    scaleControl -= 0.1f;
                    transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
                }
                colorInt = 0;
            }
        }

        //IF OUR COLOR IS GREEN
        if(playerColor == "Green")
        {
            if (colorInt == 2)
            {
                scaleControl += 0.1f;
                stickmanCount += 1;
                if (scaleControl < 3)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
                }
                colorInt = 0;
            }
            else if (colorInt == 3)
            {
                if (stickmanCount > 0)
                {
                    stickmanCount -= 1;
                }
                if (scaleControl > 1)
                {
                    scaleControl -= 0.1f;
                    transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
                }
                colorInt = 0;
            }
            else if (colorInt == 1)
            {
                if (stickmanCount > 0)
                {
                    stickmanCount -= 1;
                }
                if (scaleControl > 1)
                {
                    scaleControl -= 0.1f;
                    transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
                }
                colorInt = 0;
            }
        }

        //IF OUR COLOR IS RED
        if (playerColor == "Red")
        {
            if (colorInt == 1)
            {
                scaleControl += 0.1f;
                stickmanCount += 1;
                if (scaleControl < 3)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
                }
                colorInt = 0;
            }
            else if (colorInt == 3)
            {
                if (stickmanCount > 0)
                {
                    stickmanCount -= 1;
                }
                if (scaleControl > 1)
                {
                    scaleControl -= 0.1f;
                    transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
                }
                colorInt = 0;
            }
            else if (colorInt == 2)
            {
                if (stickmanCount > 0)
                {
                    stickmanCount -= 1;
                }
                if (scaleControl > 1)
                {
                    scaleControl -= 0.1f;
                    transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
                }
                colorInt = 0;
            }
        }
        stickmanText.text = "" + stickmanCount;
    }

    private void ChangeColor()
    {

    }



}
