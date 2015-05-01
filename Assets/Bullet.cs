using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private Rigidbody rb;
	public GameObject particle;
	private const uint NUM_PARTICLES = 30;
	// Use this for initialization
	void Start () {
		//Color color = new Color (255, 0, 0);
		//this.gameObject.GetComponent<Renderer> ().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.z == 0) {
			//print ("Adding force");
			rb.velocity = new Vector3 (0, 10, -25);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "frontwall") {
			//print ("You take Damage");
			this.explode ();
		} else if(col.gameObject.GetComponent<Enemy>() != null ) {
			col.gameObject.GetComponent<Enemy>().explode();
			this.explode ();
			//print ("Points!!");
		} else if(col.gameObject.GetComponent<Bullet>() != null ) {
			col.gameObject.GetComponent<Bullet>().explode();
			this.explode ();
		}

	}

	public void setStart(float x, float y, float z){
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (x, y, z);
	}

	private void explode()
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
