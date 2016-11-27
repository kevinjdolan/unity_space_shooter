using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float time;
	private float start;

	public void Start () {
		this.start = Time.time;
	}

	public void Update () {
		if (Time.time >= this.start + this.time) {
			Destroy (this.gameObject);
		}
	}
}
