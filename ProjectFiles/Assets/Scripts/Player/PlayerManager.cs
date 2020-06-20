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
    public bool Latched;

    private void Awake()
    {
        LatchMove = GetComponent<LatchMovement>();
        PlayCon = GetComponent<PlayerController>();
        PlayStat = GetComponent<PlayerStats>();
        Latched = false;
        rigBod = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //LatchMove.enabled = false;

        //if (PlayCon.enabled == false)
        //{
        //    PlayCon.enabled = true;
        //}

        if (PlayStat.enabled == false)
        {
            PlayStat.enabled = true;
        }




    }

    // Update is called once per frame
    void Update()
    {
        LatchCheck();
        //Latched = Latched && Input.GetKey(KeyCode.LeftShift);
        //rigBod.gravityScale = Latched ? 0 : 1;

        if (Latched == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("trying to drop");
            
            
            Debug.Log("Latched = " + Latched);
            rigBod.constraints = RigidbodyConstraints2D.None;
            rigBod.constraints = RigidbodyConstraints2D.FreezeRotation;
            Latched = false;
        

        }
    }

    public void LatchCheck() 
    {
        switch (Latched) 
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
                //rigBod.constraints = RigidbodyConstraints2D.FreezePositionX;
                rigBod.gravityScale = 0;
                PlayCon.enabled = false;
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Wall" && Input.GetKey(KeyCode.LeftShift))
        {
            if (Latched == false)
            {
                Debug.Log("Latched = " + Latched);
                rigBod.constraints = RigidbodyConstraints2D.FreezePositionX;
                Latched = true;
            }

        }
       
    }
}
