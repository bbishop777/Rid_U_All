using UnityEngine;
using System.Collections;

public class RadiusController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		//transform.position = player.transform.position;
		transform.position = player.transform.position + offset;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			Physics.IgnoreCollision (other.gameObject.transform.GetComponent<Collider> (), GetComponent<Collider> ());
		}

	}


}