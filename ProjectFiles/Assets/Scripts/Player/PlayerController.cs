using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Holds the player stats
    [HideInInspector]
    public PlayerStats play_Stats;

    [HideInInspector]
    public PlayerManager play_man;
   
    //Checks to see if the player is on a surface to jump off of
    public bool Grounded;

    public SpriteRenderer CharacterImage;
   

 

    private void Awake()
    {
        play_Stats = GetComponent<PlayerStats>();
        play_man = GetComponent<PlayerManager>();
        CharacterImage = GetComponentInChildren<SpriteRenderer>();
        Grounded = false;
     
    }

    // Update is called once per frame
    void Update()
    {

        


        //Using 2D Rigidbody physics to controll jumping, adds the gravity without any extra hassle
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            //Debug.Log("Jump pls");
            play_man.rigBod.AddForce(Vector2.up * play_Stats.CheckStats.player_JumpForce, ForceMode2D.Impulse);
        }


        //Using transform manipulation with Time.Deltatime to smooth it over
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - play_Stats.CheckStats.player_MoveSpeed * Time.deltaTime, transform.position.y);
            CharacterImage.flipX = false;
            play_man.Player_Anim.SetBool("Move", true);
            play_man.Player_Anim.Play("Player_MoveAnim");
        }
        if (Input.GetKeyUp(KeyCode.A)) 
        {
            play_man.Player_Anim.SetBool("Move", false);
           // play_man.Player_Anim.
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + play_Stats.CheckStats.player_MoveSpeed * Time.deltaTime, transform.position.y);
           CharacterImage.flipX = true;
            play_man.Player_Anim.SetBool("Move", true);
            play_man.Player_Anim.Play("Player_MoveAnim");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            play_man.Player_Anim.SetBool("Move", false);
            // play_man.Player_Anim.
        }


    }





    //Stops the player from spam jumping
    public void OnCollisionStay2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground" || Other.gameObject.tag == "Platform")
        {
            //Debug.Log("Grounded = " + Grounded);
            Grounded = true;
        }


        

    }
    public void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground" || Other.gameObject.tag == "Platform")
        {
            //Debug.Log("Grounded = " + Grounded);
            Grounded = false;
        }


    }
}
