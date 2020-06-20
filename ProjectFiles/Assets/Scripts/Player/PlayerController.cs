using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Holds the player stats
    [HideInInspector]
    public PlayerStats play_Stats;

    //Holds the player Rigidbody
    [HideInInspector]
    public Rigidbody2D rigBod;
    //Checks to see if the player is on a surface to jump off of
    public bool Grounded;

    private void Awake()
    {
        play_Stats = GetComponent<PlayerStats>();
        //Store the player rigidBody
        rigBod = GetComponent<Rigidbody2D>();
        Grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Using 2D Rigidbody physics to controll jumping, adds the gravity without any extra hassle
        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true) 
        {
            Debug.Log("Jump pls");
            rigBod.AddForce(Vector2.up * play_Stats.CheckStats.player_JumpForce, ForceMode2D.Impulse);
        }


        //Using transform manipulation with Time.Deltatime to smooth it over
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.position = new Vector2(transform.position.x - play_Stats.CheckStats.player_MoveSpeed * Time.deltaTime, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + play_Stats.CheckStats.player_MoveSpeed * Time.deltaTime, transform.position.y);
        }

    }

    //Stops the player from spam jumping
    public void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground" || Other.gameObject.tag == "Wall" || Other.gameObject.tag == "Platform")
        {
            Debug.Log(Grounded);
            Grounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Ground" || Other.gameObject.tag == "Wall" || Other.gameObject.tag == "Platform")
        {
            Debug.Log(Grounded);
            Grounded = false;
        }
    }
}
