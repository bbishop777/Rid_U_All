﻿using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
//	public Text countText;
//	public Text winText;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
//		count = 0;
//		SetCountText ();
//		winText.text = "";

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
		

	void OnTriggerEnter(Collider other) 
	{	
		if (other.gameObject.CompareTag ("Radius")) 
		{
			Physics.IgnoreCollision (other.gameObject.transform.GetComponent<Collider> (), GetComponent<Collider> ());
		}

//		if(other.gameObject.CompareTag("Pick Up"))
//		{
//			other.gameObject.SetActive (false);
//			count = count + 1;
//			SetCountText ();
//		}

		if (other.gameObject.CompareTag ("Dynamite")) 
		{
			Physics.IgnoreCollision (other.gameObject.transform.GetComponent<Collider> (), GetComponent<Collider> ());
		}
	}

//	void SetCountText ()
//	{
//		countText.text = "Count: " + count.ToString ();
//		if (count >= 14)
//		{
//			winText.text = "You Win All 72!";
//		}
//	}
}
 