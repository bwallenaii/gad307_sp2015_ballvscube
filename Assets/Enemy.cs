using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Rigidbody rb;
	public GameObject particle;
	private const uint NUM_PARTICLES = 30;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		this.attackMode ();
		//Color color = new Color (100, 100, 0);
		//this.gameObject.GetComponent<Renderer> ().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.z == 0) {
			this.attackMode();
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "frontwall") {
			Player.player.takeHit(this);
			this.explode ();
		}
	}

	private void attackMode()
	{
		rb.velocity = new Vector3 (Random.Range(-8, 8), Random.Range(-8, 8), 25);
	}

	public void explode()
	{
		Destroy(this.gameObject);
		for (uint i = 0; i < NUM_PARTICLES; ++i) {
			GameObject part = Instantiate(particle);
			Vector3 pos = part.transform.position;
			part.transform.position = this.transform.position;
			part.GetComponent<Rigidbody>().velocity = this.rb.velocity;
		}
	}
}
