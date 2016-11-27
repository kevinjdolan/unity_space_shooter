using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Vector3 spawnPrototype;
	public GameObject asteroid;
	public Text scoreText;

	public float waitStart = 1.0f;
	public float waitWave = 3.0f;
	public float waitAsteroidMin = 0.5f;
	public float waitAsteroidMax = 1.0f;
	public int waveHazardsMin = 5;
	public int waveHazardsMax = 20;

	private int score = 0;

	public void Start () {
		this.StartCoroutine (this.SpawnWaves ());
		this.UpdateScore ();
	}

	private IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (this.waitStart);
		while (true) {
			int waveSize = Random.Range (this.waveHazardsMin, this.waveHazardsMax);
			for (int i = 0; i < waveSize; i++) {
				this.SpawnAsteroid ();
				float wait = Random.Range (this.waitAsteroidMin, this.waitAsteroidMax);
				yield return new WaitForSeconds (wait);
			}
			yield return new WaitForSeconds (this.waitWave);
		}
	}

	public void AddToScore(int amount) {
		this.score += amount;
		this.UpdateScore ();
	}

	private void SpawnAsteroid () {
		Vector3 spawnPosition = new Vector3 (
			Random.Range(-this.spawnPrototype.x, this.spawnPrototype.x),
			this.spawnPrototype.y,
			this.spawnPrototype.z
		);
		Instantiate (
			this.asteroid,
			spawnPosition,
			Quaternion.identity
		);
	}

	private void UpdateScore() {
		this.scoreText.text = "Score: " + this.score.ToString();
	}
}
