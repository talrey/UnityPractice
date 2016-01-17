using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private int state, score;
	
	private const int testSeed = 101;
	
	//private GameObject player;
	public GameObject asteroidPrefab;
	
	public const int STATE_MENU = 0;
	public const int STATE_RUNNING = 1;
	public const int STATE_PAUSED = 2;
	
	// Use this for initialization
	void Start () {
		state = 0; // main menu state
		score = 0;
		//player = GameObject.Find("player object name");
		//asteroidPrefab = Resources.Load("Prefabs/ShoutBullet_Prefab") as GameObject;
		StartCoroutine(TryToAsteroid());
		
		// will replace with something 'random' like time, later.
		Random.seed = testSeed;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
			case STATE_MENU:
				break;
			case STATE_RUNNING:
				if (Input.GetButtonDown("Cancel")) {
					Pause();
				}
				break;
			case STATE_PAUSED:
				if (Input.GetButtonDown("Cancel")) {
					Resume();
				}
				break;
		}
	}
	
	/* State:
	Menu:
		[start] / state=RUNNING
		[quit]  / <exit application>
	Running:
		<pause> / state=PAUSED
	Paused:
		[resume]/ state=RUNNING
		[quit]  / state=Menu
	*/
	void OnGUI () {
		switch (state) {
			case STATE_MENU:
				if (GUI.Button(
				new Rect(Screen.width/2-50,Screen.height/2,100,30), "Start Game")) {
					//Debug.Log("game started");
					Resume();
				}
				else if (GUI.Button(
				new Rect(Screen.width/2-50,Screen.height/2+30,100,30), "Quit")) {
					Debug.Log("game quit?");
				}
				break;
			case STATE_RUNNING:
				GUI.Label(new Rect(0,0,100,30), "Score: " + score);
				break;
			case STATE_PAUSED:
				GUI.Label(new Rect(0,0,100,30), "Score: " + score);
				if (GUI.Button(
				new Rect(Screen.width/2-50,Screen.height/2,100,30), "Resume")) {
					Debug.Log("game resumed");
					Resume();
				}
				else if (GUI.Button(
				new Rect(Screen.width/2-50,Screen.height/2+30,100,30), "Quit")) {
					//Debug.Log("game quit");
					state = STATE_MENU;
					// save score
				}
				break;
		}
	}
	
	private void Pause () {
		Time.timeScale = 0;
		state = STATE_PAUSED;
	}
	
	private void Resume () {
		Time.timeScale = 1;
		state = STATE_RUNNING;
	}
	
	// Coroutine that tries to create an asteroid.
	// We say "Try" because it's based on RNG and difficulty.
	// It isn't a guarantee that one will appear.
	private IEnumerator TryToAsteroid () {
		for (;;) {
			//Debug.Log("asteroid away?");
			switch (state) {
				case STATE_MENU:
					//if (Random.value > 0.5f) {
						CreateAsteroid(false);
					//}
					break;
				case STATE_RUNNING:
					//if (Random.value > 0.5f) { // change this later
						CreateAsteroid(true);
					//}
					break;
				case STATE_PAUSED:
					// never create asteroids here
					break;
			}
			// we're an infinite loop, but we don't lock the game.
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	// Creates an asteroid object, including locating it
	// and telling it if it can wrap around the screen.
	private void CreateAsteroid (bool canWrap) {
		Debug.Log("creating asteroid");
		GameObject asteroidDupe = Instantiate(asteroidPrefab, onCircle(Random.value*2*Mathf.PI,10), Random.rotation) as GameObject;
		asteroidDupe.GetComponent<Wrappable>().canWrap = canWrap;
		asteroidDupe.GetComponent<Rigidbody2D>().AddForce(onCircle(Random.value*2*Mathf.PI,0.1f));
	}
	
	private Vector3 onCircle (float angle, float radius) {
		return new Vector3(radius*Mathf.Cos(angle),radius*Mathf.Sin(angle),0);
	}
	
	public int GetGameState () {
		return state;
	}
	
	public void AddToScore (int value) {
		score += value;
	}
}
