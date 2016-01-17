using UnityEngine;
using System.Collections;

public class Wrappable : MonoBehaviour {
	private GameObject playerCam;
	
	public bool canWrap;
	
	public const float widthBorder  = 100.0f;
	public const float heightBorder = 100.0f;

	// Use this for initialization
	void Start () {
		canWrap = true;
		playerCam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = transform.position.x;
		float y = transform.position.y;
		
		if (x > playerCam.transform.position.x + widthBorder) {
			if (!canWrap) Destroy(gameObject);
			else x = -widthBorder;
		}
		else if (x < -widthBorder) {
			if (!canWrap) Destroy(gameObject);
			else x = playerCam.transform.position.x + widthBorder;
		}
		if (y > playerCam.transform.position.y + heightBorder) {
			if (!canWrap) Destroy(gameObject);
			else y = -heightBorder;
		}
		else if (y < -heightBorder) {
			if (!canWrap) Destroy(gameObject);
			else y = playerCam.transform.position.y + heightBorder;
		}
		transform.position = new Vector3(x,y,0f);
	}
}
