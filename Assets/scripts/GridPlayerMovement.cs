using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public Animator anim;

    public float CryAnimTimer;
    bool CryAnimStart = false;

    private void Start()
    {
        movePoint.parent = null;

    }

    // Update is called once per frame
    void Update()
    {
        //moves player to move point
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        //checks if move point can be moves
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            //checks if horizontal input has been pressed
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {

                //checks if collision in the way
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    //moves move point in horizontal axis
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    //moves move point in vertical axis

                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }

            }

            anim.SetBool("moving", false);

        }
        else
        {
            anim.SetBool("moving", true);
            CryAnimTimer = 0;
        }


        if (Input.GetKey(KeyCode.G) && CryAnimStart == false)
        {
            anim.SetBool("Cry", true);
            Debug.Log("CRy");

            CryAnimStart = true;
            
        }

        if(CryAnimStart == true)
        {
            CryAnimTimer -= Time.deltaTime;

            if (CryAnimTimer <= 0)
            {
                anim.SetBool("Cry", false);
                CryAnimTimer = 2.1f;
                CryAnimStart = false;
            }
        }
        


    }

    
}
