using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore : MonoBehaviour
{

    public Rigidbody2D SporeBod;
    public int Force;
    public PlayerStats P_Stat;

    // Start is called before the first frame update
    void Start()
    {
        SporeBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        //SporeBod.AddForce(transform.forward * Force);
        transform.position = transform.position += -(transform.up * Force) * Time.deltaTime;
    }
    void FixedUpdate()
    {
        //SporeBod.AddForce(transform.forward * Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);

        if (collision.gameObject.tag == "Player")
        {
            P_Stat = collision.gameObject.GetComponent<PlayerStats>();
           // print("Player hit");
            //collision.gameObject.GetComponent<PlayerStats>().CheckStats.player_HP += -1;
            P_Stat.CheckStats.player_HP += -1;
            print(P_Stat.CheckStats.player_HP);
        }

    }
}
