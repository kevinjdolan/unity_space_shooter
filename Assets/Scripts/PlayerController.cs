using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	public float bank = 30.0f;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;

	public Boundary boundary;

	public GameObject shotPrefab;
	public Transform shotSpawn;
	public GameObject explosionPrefab;

	private Rigidbody body;
	private AudioSource blasterSound;

	public void Start () {
		this.blasterSound = this.GetComponent<AudioSource> ();
		this.body = this.GetComponent<Rigidbody> ();
	}

	public void Update() {
		this.PossiblyFireShot ();
	}

	public void FixedUpdate() {
		this.ApplyControls ();
	}

	public void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Asteroid") {
			this.Collide (other);
		}
	}

	private void ApplyControls () {
		float hv = Input.GetAxis ("Horizontal");
		float vv = Input.GetAxis ("Vertical");
		this.body.velocity = new Vector3 (
			hv * this.speed,
			0.0f,
			vv * this.speed
		);
		this.body.position = new Vector3 (
			Mathf.Clamp(this.body.position.x, this.boundary.xMin, this.boundary.xMax),
			0.0f,
			Mathf.Clamp(this.body.position.z, this.boundary.zMin, this.boundary.zMax)
		);
		this.body.rotation = Quaternion.Euler (
			0.0f,
			0.0f,
			-hv * this.bank
		);
	}

	private void Collide(Collider other) {
		Destroy (this.gameObject);
		Instantiate (this.explosionPrefab, this.transform.position, this.transform.rotation);
	}

	private void PossiblyFireShot() {
		if(Input.GetButton("Jump") && Time.time > this.nextFire) {
			this.nextFire = Time.time + this.fireRate;
			Instantiate (
				this.shotPrefab,
				this.shotSpawn.position,
				this.shotSpawn.rotation
			);
			this.blasterSound.Play();
		}
	}
}
