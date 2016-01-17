using UnityEngine;
using System.Collections;

public class Wrappable : MonoBehaviour {
	private GameObject playerCam;
	
	public bool canWrap;
	public float borderOffsetHeight = 4.0f;
	public float borderOffsetWidth = 4.0f;
	private float widthBorder  = 20.0f;
	private float heightBorder = 20.0f;

	// Use this for initialization
	void Start () {
		canWrap = true;
		playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        float camSize = playerCam.GetComponent<Camera>().orthographicSize;
		heightBorder =  camSize + borderOffsetHeight;
		widthBorder = camSize + borderOffsetWidth;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = transform.position.x;
		float y = transform.position.y;
		float camx = playerCam.transform.position.x;
		float camy = playerCam.transform.position.y;
		
		if (x > camx + widthBorder) {
			if (!canWrap) Destroy(gameObject);
			else x = camx - widthBorder;
		}
		else if (x < camx - widthBorder) {
			if (!canWrap) Destroy(gameObject);
			else x = camx + widthBorder;
		}
		if (y > camy + heightBorder) {
			if (!canWrap) Destroy(gameObject);
			else y = camy - heightBorder;
		}
		else if (y < camy - heightBorder) {
			if (!canWrap) Destroy(gameObject);
			else y = camy + heightBorder;
		}
		transform.position = new Vector3(x,y,0f);
	}
}
