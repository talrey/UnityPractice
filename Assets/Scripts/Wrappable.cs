using UnityEngine;
using System.Collections;

public class Wrappable : MonoBehaviour {
	public bool canWrap;
	
	public const float widthBorder  = 10.0f;
	public const float heightBorder = 10.0f;

	// Use this for initialization
	void Start () {
		canWrap = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = transform.position.x;
		float y = transform.position.y;
		
		if (x > Screen.width + widthBorder) {
			if (!canWrap) Destroy(gameObject);
			else x = -widthBorder;
		}
		else if (x < -widthBorder) {
			if (!canWrap) Destroy(gameObject);
			else x = Screen.width + widthBorder;
		}
		if (y > Screen.height + heightBorder) {
			if (!canWrap) Destroy(gameObject);
			else y = -heightBorder;
		}
		else if (y < -heightBorder) {
			if (!canWrap) Destroy(gameObject);
			else y = Screen.height + heightBorder;
		}
		transform.position = new Vector3(x,y,0f);
	}
}
