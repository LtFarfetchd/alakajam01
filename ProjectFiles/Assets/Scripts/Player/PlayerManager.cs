using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public LatchMovement LatchMove;
    public PlayerStats PlayStat;
    public PlayerController PlayCon;

    [HideInInspector]
    public Rigidbody2D rigBod;

    //Check whether or not the player is latched to something.
    public bool WallLatched;
    public bool RoofLatched;
    public bool CreatureLatched;

    private void Awake()
    {
        LatchMove = GetComponent<LatchMovement>();
        PlayCon = GetComponent<PlayerController>();
        PlayStat = GetComponent<PlayerStats>();
        WallLatched = false;
        RoofLatched = false;
        rigBod = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (PlayStat.enabled == false)
        {
            PlayStat.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (WallLatched == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //rigBod.constraints = RigidbodyConstraints2D.None;
            //rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            WallLatched = false;

            LatchMove.enabled = false;
            rigBod.constraints = RigidbodyConstraints2D.None;
            rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigBod.gravityScale = 1;
            PlayCon.enabled = true;
            Debug.Log("Wall Latch = " + WallLatched);

        }

        if (RoofLatched == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //rigBod.constraints = RigidbodyConstraints2D.None;
            //rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            RoofLatched = false;

            LatchMove.enabled = false;
            rigBod.constraints = RigidbodyConstraints2D.None;
            rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigBod.gravityScale = 1;
            PlayCon.enabled = true;
            Debug.Log("Roof Latch = " + RoofLatched);

        }
    }

    public void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "LatchWall" && Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Roof Latch_Collision = " + RoofLatched);
            if (WallLatched == false)
            {
                WallLatched = true;
                LatchMove.enabled = true;
                rigBod.constraints = RigidbodyConstraints2D.FreezePositionX;
                rigBod.gravityScale = 0;
                PlayCon.enabled = false;
            }

        }
        if (Other.gameObject.tag == "LatchRoof" && Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Roof Latch_Collision = " + RoofLatched);
            if (RoofLatched == false)
            {
                RoofLatched = true;
                LatchMove.enabled = true;
                rigBod.constraints = RigidbodyConstraints2D.FreezePositionY;
                rigBod.gravityScale = 0;
                PlayCon.enabled = false;
                Debug.Log("Roof Latch = " + RoofLatched);
            }

        }

    }

    private void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "LatchWall" && WallLatched == true) 
        {
            WallLatched = false;
            LatchMove.enabled = false;
            rigBod.constraints = RigidbodyConstraints2D.None;
            rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigBod.gravityScale = 1;
            PlayCon.enabled = true;
        }

        if (Other.gameObject.tag == "LatchRoof" && RoofLatched == true) 
        {
            RoofLatched = false;

            LatchMove.enabled = false;
            rigBod.constraints = RigidbodyConstraints2D.None;
            rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigBod.gravityScale = 1;
            PlayCon.enabled = true;
        }
    }
}
