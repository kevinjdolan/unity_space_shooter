using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	public GameObject explosion;
	public int score;

	private GameController controller;

	public void Start() {
		GameObject controllerObj = GameObject.FindWithTag ("GameController");
		this.controller = controllerObj.GetComponent<GameController> ();
	}

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Bolt") {
			Destroy (other.gameObject);
			this.Explode ();
		} else if (other.gameObject.tag == "Player") {
			this.Explode ();
			//Player keeps track of its own need to explode
		}
	}

	private void Explode() {
		Destroy (this.gameObject);
		Instantiate (this.explosion, this.transform.position, this.transform.rotation);
		this.controller.AddToScore (this.score);
	}

}
