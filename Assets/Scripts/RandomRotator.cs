using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float spin = 5.0f;

	public void Start () {
		Rigidbody body = this.GetComponent<Rigidbody> ();
		body.angularVelocity = Random.insideUnitSphere * this.spin;
	}

}
