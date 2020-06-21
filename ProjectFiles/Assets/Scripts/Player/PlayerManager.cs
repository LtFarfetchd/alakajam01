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
    [HideInInspector]
    public Collider2D Player_Collider;

    //Check whether or not the player is latched to something.
    public bool WallLatched;
    public bool RoofLatched;
    public bool CreatureLatched;
    public bool UnlatchPls;

    public CreatureStats Victim_Stats;
    
    [HideInInspector]
    public CreatureMovement CreatureControl;

    public GameObject Prey;
    private void Awake()
    {
        LatchMove = GetComponent<LatchMovement>();
        PlayCon = GetComponent<PlayerController>();
        PlayStat = GetComponent<PlayerStats>();
        WallLatched = false;
        RoofLatched = false;
        CreatureLatched = false;
        UnlatchPls = false;
        Player_Collider = GetComponent<Collider2D>();
        rigBod = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (PlayStat.enabled == false)
        {
            PlayStat.enabled = true;
        }

        if (Player_Collider.enabled == false)
        {
            Player_Collider.enabled = true;
        }
        }

    // Update is called once per frame
    void Update()
    {
        if (CreatureLatched == true) 
        {
            //Victim_Stats = GetComponentInParent<CreatureStats>();
            gameObject.transform.position = Victim_Stats.LatchPoint.transform.position;
            rigBod.isKinematic = true;
            Player_Collider.enabled = false;
        }

        Debug.Log("CreatureLatched = " + CreatureLatched);

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

        if (Input.GetKeyDown(KeyCode.LeftShift) ) 
        {
            if (CreatureLatched == true) 
            {
                Debug.Log("Unlatch pls");
                StartCoroutine(UnlatchTimer());
                transform.parent = null;
                CreatureLatched = false;
                CreatureControl.enabled = false;
                Victim_Stats = null;
                CreatureControl = null;
                Player_Collider.enabled = true;
                //Physics2D.IgnoreCollision(Player_Collider, Prey.gameObject.GetComponent<Collider2D>());
               // Prey = null;

                rigBod.isKinematic = false;
                if (CreatureControl == true)
                {
                    CreatureControl.enabled = false;
                }
                if (PlayCon.enabled == false)
                {
                    PlayCon.enabled = true;
                }
            }
            

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

        if (Other.gameObject.tag == "Creature" && Input.GetKey(KeyCode.LeftShift)) 
        {
            if (CreatureLatched == false && UnlatchPls == false) 
            {
                CreatureLatched = true;
                //CreatureControl = GetComponentInParent<CreatureMovement>();
                transform.parent = Other.transform;
                CreatureControl = Other.gameObject.GetComponent<CreatureMovement>();
                Victim_Stats = Other.gameObject.GetComponent<CreatureStats>();
                gameObject.transform.position = Victim_Stats.LatchPoint.transform.position;
                //Prey = Other.gameObject;
                if (CreatureControl.enabled == false)
                {
                    CreatureControl.enabled = true;
                }
                if (PlayCon.enabled == true)
                {
                    PlayCon.enabled = false;
                }

                if (LatchMove.enabled == true)
                {
                    LatchMove.enabled = false;
                }
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

    public IEnumerator UnlatchTimer() 
    {
        if (UnlatchPls == false) 
        {
            UnlatchPls = true;
        }
        yield return new WaitForSeconds(3);
        UnlatchPls = false;
        StopAllCoroutines();
    }

}
