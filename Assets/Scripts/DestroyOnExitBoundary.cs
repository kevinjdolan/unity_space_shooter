using UnityEngine;
using System.Collections;

public class DestroyOnExitBoundary : MonoBehaviour {

	void OnTriggerExit (Collider other) {
		Destroy (other.gameObject);
	}
}
