using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject bullet;
	private float speed = 35f;
	private static Player _player;
	// Use this for initialization
	void Start () {
		_player = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject bul = Instantiate(bullet);
			Vector3 pos = this.transform.position;
			Vector3 dir = new Vector3(this.percentage(Input.mousePosition.x,Screen.width),
			                          this.percentage(Input.mousePosition.y,Screen.height),
			                          pos.z - 30);

			float angle = (float) GetAngleToPoint(pos, dir);
			Vector3 vel = new Vector3(-this.speed * (float)Mathf.Cos(angle),
			            this.speed * (float)Mathf.Sin(angle), -20);

			
			bul.GetComponent<Bullet>().setStart(vel.x, vel.y, vel.z);
		}
	}

	private float percentage(double num, double max)
	{
		double perc = num / max;
		perc -= .5;
		return (float) perc * 10;
	}

	public static double GetAngleToPoint(Vector3 startingPoint, Vector3 endPoint)
	{
		endPoint -= startingPoint;
		return Mathf.Atan2(endPoint.y, endPoint.x);
	}

	public static Player player{
		get {
			return _player;
		}
	}

	public void takeHit(Enemy en){
		print ("oweeee!!");
	}
}
