using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private int state;
	
	//private GameObject player;
	private GameObject asteroidPrefab;
	
	public const int STATE_MENU = 0;
	public const int STATE_RUNNING = 1;
	public const int STATE_PAUSED = 2;
	
	// Use this for initialization
	void Start () {
		state = 0; // main menu state
		//player = GameObject.Find("player object name");
		asteroidPrefab = Resources.Load("Prefabs/Asteroid") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
			case STATE_MENU:
				// draw buttons
				// spawn asteroids w/ no wrap-around
				
				// state switch conditions:
				// Button(game_start) / state=RUNNING, show player
				break;
			case STATE_RUNNING:
				// spawn asteroids w/ wrap-around
				// draw score on screen
				
				// state switch conditions:
				// Pause / state=PAUSED, disable movement
				break;
			case STATE_PAUSED:
				// draw buttons
				
				// state switch conditions:
				// Unpause / state=1, enable movement
				// Quit / state=MENU, save score, hide player
				break;
		}
	}
	
	void OnGUI () {
		switch (state) {
			case STATE_MENU:
				break;
			case STATE_RUNNING:
				break;
			case STATE_PAUSED:
				break;
		}
	}
	
	private void Pause () {
		switch (state) {
			case STATE_MENU: break; // do nothing
			case STATE_RUNNING:
				Time.timeScale = 0;
				state = STATE_PAUSED;
				break;
			case STATE_PAUSED:
				Time.timeScale = 1;
				state = STATE_RUNNING;
				break;
		}
	}
	
	// Coroutine that tries to create an asteroid.
	// We say "Try" because it's based on RNG and difficulty.
	// It isn't a guarantee that one will appear.
	private IEnumerator TryToAsteroid () {
		for (;;) {
			switch (state) {
				case STATE_MENU:
					// check the RNG
					// if should, CreateAsteroid(false);
					break;
				case STATE_RUNNING:
					// check the RNG
					// if should, CreateAsteroid(true);
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
		GameObject asteroidDupe = Instantiate(asteroidPrefab);
		Destroy(asteroidDupe); // obvious placeholder is obvious
	}
	
	public int GetGameState () {
		return state;
	}
}
