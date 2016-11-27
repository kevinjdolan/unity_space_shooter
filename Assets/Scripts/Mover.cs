using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed = 20f;

	// Use this for initialization
	public void Start () {
		Rigidbody body = this.GetComponent<Rigidbody> ();
		body.velocity = this.transform.forward * this.speed;
	}

}
