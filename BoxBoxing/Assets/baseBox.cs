using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseBox : MonoBehaviour {

	public Rigidbody rig;
	public float speed;
	public float jumpspeed;
	public bool p2;
	public bool isGrabbed;

	
	// Update is called once per frame
	void Update ()
	{
		float x = getHorizontal ();
		x *= speed;
		float z = getVertical ();
		z *= speed;
		float y = getJump ();
		y *= jumpspeed;
		Vector3 dir = new Vector3 (x, y, z); 
		rig.AddForce (dir);
		if (!p2 && Input.GetKeyUp (KeyCode.LeftControl)) {
			letGo ();
		} else if (p2 && Input.GetKeyUp (KeyCode.RightControl)) {
			letGo ();
		}
	}

	float getHorizontal()
	{if (!p2) {
			return Input.GetAxis ("Horizontal");
		} else {
		return Input.GetAxis ("Horizontal2");
		}
	}
	float getVertical()
	{if (!p2) {
		return Input.GetAxis ("Vertical");
	} else {
		return Input.GetAxis ("Vertical2");
	}
	}
	float getJump()
		{if (!p2) {
		return Input.GetAxis ("Jump");
	} else {
		return Input.GetAxis ("Jump2");
	}
		

	}

	public void OnCollisionEnter(Collision Coll)
	{
		if (Coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.LeftControl) && !p2) {
			Coll.gameObject.transform.SetParent (gameObject.transform);
			Debug.Log ("grabbed");
		}
		if (Coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.RightControl) && p2) {
			Coll.gameObject.transform.SetParent (gameObject.transform);
			Debug.Log ("grabbed");
		}
	}

	public void letGo()
	{
		transform.GetChild (0).GetComponent<Rigidbody> ().velocity = rig.velocity * (speed / 5);
		transform.DetachChildren ();
	}
}
