using UnityEngine;
using System.Collections;

public class Wrappable : MonoBehaviour {
	private GameObject camera;
	
	public bool canWrap;
	
	public const float widthBorder  = 100.0f;
	public const float heightBorder = 100.0f;

	// Use this for initialization
	void Start () {
		canWrap = true;
		GameObject.FindGameObjectWithTag("Main Camera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = transform.position.x;
		float y = transform.position.y;
		
		if (x > camera.transform.x + widthBorder) {
			if (!canWrap) Destroy(gameObject);
			else x = -widthBorder;
		}
		else if (x < -widthBorder) {
			if (!canWrap) Destroy(gameObject);
			else x = camera.transform.x + widthBorder;
		}
		if (y > camera.transform.y + heightBorder) {
			if (!canWrap) Destroy(gameObject);
			else y = -heightBorder;
		}
		else if (y < -heightBorder) {
			if (!canWrap) Destroy(gameObject);
			else y = camera.transform.y + heightBorder;
		}
		transform.position = new Vector3(x,y,0f);
	}
}
