using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		this.attackMode ();
		Color color = new Color (100, 100, 0);
		this.gameObject.GetComponent<Renderer> ().material.color = color;
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
			//print ("You take Damage");
			this.explode ();
		}
	}

	private void attackMode()
	{
		rb.velocity = new Vector3 (Random.Range(-8, 8), Random.Range(-8, 8), 35);
	}

	public void explode()
	{
		Destroy(this.gameObject);
	}
}
