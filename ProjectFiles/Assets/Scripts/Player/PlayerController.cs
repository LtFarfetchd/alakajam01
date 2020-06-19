using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Jump Force controller, adjust in editor
    public float jumpForce;
    //movement speed controller, adjust in editor
    public float moveSpeed;
    //Store the player rigidbody, takes care of itself
    public Rigidbody2D rigBod;

    private void Awake()
    {
        //Store the player rigidBody
        rigBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Using 2D Rigidbody physics to controll jumping, adds the gravity without any extra hassle
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Jump pls");
            rigBod.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        //Using transform manipulation with Time.Deltatime to smooth it over
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }

    }
}
