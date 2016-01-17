using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private int state;
	
	// Use this for initialization
	void Start () {
		state = 0; // main menu state
	}
	
	// Update is called once per frame
	void Update () {
		switch (state)
		{
			case 0: // main menu state
				// draw buttons
				// spawn asteroids w/ no wrap-around
				
				// state switch conditions:
				// Button(game_start) / state=1, show player
				break;
			case 1: // game state
				// spawn asteroids w/ wrap-around
				// draw score on screen
				
				// state switch conditions:
				// Pause / state=2, disable movement
				break;
			case 2: // pause state
				// draw buttons
				
				// state switch conditions:
				// Unpause / state=1, enable movement
				// Quit / state=0, save score, hide player
				break;
		}
	}
}
