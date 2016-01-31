using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadiusController : MonoBehaviour {
	public Text countText;
	public Text winText;
	public GameObject player;
	private int count;
	private bool triggerPressed;
	private float rad = 7.5f;

	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		count = 0;
		SetCountText ();
		winText.text = "";
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{	
		transform.position = player.transform.position + offset;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ExplosionDamage (transform.position, rad);
//			triggerPressed = true;
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			triggerPressed = false;
		}
	}

	void ExplosionDamage(Vector3 center, float radius) {
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		int i = 0;
		while (i < hitColliders.Length) {
			hitColliders[i].gameObject.SetActive (false);
			i++;
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up") && triggerPressed == true)
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("Player")) 
		{
			Physics.IgnoreCollision (other.gameObject.transform.GetComponent<Collider> (), GetComponent<Collider> ());
		}
//		if(other.gameObject.CompareTag("Pick Up"))
//		{
//			//other.gameObject.SetActive (false);
//			count = count + 1;
//			SetCountText ();
//			if (count >= 14) {
//				winText.text = "You Win!";
//			}
//		}
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