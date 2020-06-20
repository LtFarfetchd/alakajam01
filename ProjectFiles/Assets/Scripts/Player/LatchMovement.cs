using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchMovement : MonoBehaviour
{
    [HideInInspector]
    public PlayerStats play_Stats;

    [HideInInspector]
    public PlayerController play_Con;
    [HideInInspector]
    public PlayerManager play_man;

    public Rigidbody2D player_Bod;


    public Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    {
        play_Con = GetComponent<PlayerController>();
        play_Stats = GetComponent<PlayerStats>();
        play_man = GetComponent<PlayerManager>();

        player_Bod = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        MovePlayer(movement);
    }
    void MovePlayer(Vector2 direction)
    {
        player_Bod.MovePosition((Vector2)transform.position + (direction * play_Stats.CheckStats.player_MoveSpeed * Time.deltaTime));
    }
}
