using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private int timer;
	public GameObject enemy;
	private const int LOW_TIME = 0;
	private const int HIGH_TIME = 120;
	// Use this for initialization
	void Start () {
	
		this.timer = Mathf.CeilToInt( Random.Range (LOW_TIME, HIGH_TIME));
	}
	
	// Update is called once per frame
	void Update () {
		this.timer--;
		if (this.timer <= 0) {
			this.timer = Mathf.CeilToInt( Random.Range (LOW_TIME, HIGH_TIME));
			Instantiate(enemy);

		}
	}
}
