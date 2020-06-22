using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{

	public float amplitude;          //Set in Inspector Only Edit these two variables in the inspector.
	public float speed;              //Set in Inspector 
	public float tempVal;
	public Vector2 CurrentPos;
	public Vector2 tempPos;
	void Start()
	{
		tempVal = transform.position.y;


		//Un-comment this amplitude and comment out the one below it for more random results, change the values to your liking if you do so.
		//amplitude = Random.Range (0.1f, 0.3f); 
		amplitude = 0.2f;


		//Un-comment this speed and comment out the one below it for more random results, change the values to your liking if you do so.
		//speed = Random.Range(0.5f, 3.00f);
		speed = 2.00f;
	}
	void Update()
	{
		tempPos.y =  + tempVal + amplitude * Mathf.Sin(speed * Time.time);
		tempPos.x = transform.position.x;
		transform.position = tempPos;
		//gameObject.transform.position.x = transform.position.x + tempPos.x;


	}
}
