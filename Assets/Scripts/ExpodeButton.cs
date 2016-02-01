using UnityEngine;
using System.Collections;

public class ExpodeButton : MonoBehaviour {

	public string buttonName = "Fire1";
	public float force = 100.0f;
	public float radius = 5.0f;
	//Use forceMode impulse for faster acceleration
	public ForceMode forceMode;
	public float upMod = 0.0f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
			foreach (Collider col in Physics.OverlapSphere(transform.position, radius)) {
				if (col.CompareTag("Pick Up")) {
					col.GetComponent<Rigidbody>().AddExplosionForce (force, transform.position, radius, upMod, forceMode);
				}
			}
		}
	}
}
