using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadiusController : MonoBehaviour {
	public Text countText;
	public Text winText;
	public GameObject player;
	private int count;

	private Vector3 offset;
	// Use this for initialization
	void Start () 
	{
		count = 0;
		SetCountText ();
		winText.text = "";
		offset = transform.position - player.transform.position;
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		//transform.position = player.transform.position;
		transform.position = player.transform.position + offset;
	}

	void OnTriggerEnter(Collider other)
	{
//		if(other.gameObject.CompareTag("Pick Up"))
//		{
//			other.gameObject.SetActive (false);
//			count = count + 1;
//			SetCountText ();
//		}
		if (other.gameObject.CompareTag ("Player")) 
		{
			Physics.IgnoreCollision (other.gameObject.transform.GetComponent<Collider> (), GetComponent<Collider> ());
		}
		if(other.gameObject.CompareTag("Pick Up"))
		{
			//other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 14)
		{
			winText.text = "You Win All 72 Virgins!";
		}
	}
		
}