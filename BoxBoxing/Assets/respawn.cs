using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	void OnTriggerEnter(Collider Coll)
	{
		Coll.gameObject.transform.SetPositionAndRotation (new Vector3(3, 0, -4), Quaternion.identity);
		Coll.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
