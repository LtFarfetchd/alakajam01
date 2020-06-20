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
        WallLatchCheck();
        //RoofLatchCheck();
        //Latched = Latched && Input.GetKey(KeyCode.LeftShift);
        //rigBod.gravityScale = Latched ? 0 : 1;

        if (WallLatched == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            rigBod.constraints = RigidbodyConstraints2D.None;
            rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            WallLatched = false;
        }

        if (RoofLatched == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            rigBod.constraints = RigidbodyConstraints2D.None;
            rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            RoofLatched = false;
        }
    }

    public void WallLatchCheck() 
    {
        switch (WallLatched) 
        {
            case false:
                LatchMove.enabled = false;
                rigBod.constraints = RigidbodyConstraints2D.None;
                rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
                rigBod.gravityScale = 1;
                PlayCon.enabled = true;
                break;
            case true:
                LatchMove.enabled = true;
                rigBod.constraints = RigidbodyConstraints2D.FreezePositionX;
                rigBod.gravityScale = 0;
                PlayCon.enabled = false;
                break;
        }
    }

    public void RoofLatchCheck() 
    {
        switch (RoofLatched) 
        {
            case false:
                LatchMove.enabled = false;
                rigBod.constraints = RigidbodyConstraints2D.None;
                rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
                rigBod.gravityScale = 1;
                PlayCon.enabled = true;
                break;
            case true:
                LatchMove.enabled = true;
                rigBod.constraints = RigidbodyConstraints2D.FreezePositionY;
                rigBod.gravityScale = 0;
                PlayCon.enabled = false;
                break;
           
        }
    }

    public void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "LatchWall" && Input.GetKey(KeyCode.LeftShift))
        {
            if (WallLatched == false)
            {
                WallLatched = true;
            }

        }
        if (Other.gameObject.tag == "LatchRoof" && Input.GetKey(KeyCode.LeftShift))
        {
            if (RoofLatched == false)
            {
                RoofLatched = true;
            }

        }

    }
}
