using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum State {cell, mirror, sheets, lock_0, cell_mirror, lock_1, freedom};
	private State myState;
	private State myPrevState;
	
	// Use this for initialization
	void Start () {
		myState = State.cell;
		myPrevState = State.cell;
		text.text = "You wake up... \n\n" + 
					"Hit [Enter]";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("return") && myState == State.cell) {
			cell_state();
			
		} else if (Input.GetKeyDown(KeyCode.R)) {
			if (myPrevState == State.cell) {
				cell_state();
			} else if (myPrevState == State.cell_mirror) {
				cell_mirror_state();
			}
		} else if (Input.GetKeyDown(KeyCode.M)) {
			mirror_state();
		} else if (Input.GetKeyDown(KeyCode.L)) {
			lock_0_state();
		} else if (Input.GetKeyDown(KeyCode.S)) {
			sheets_state();
		} else if (Input.GetKeyDown(KeyCode.T)) {
			cell_mirror_state();
			myPrevState = State.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.C)) {
			lock_1_state();
		} else if (Input.GetKeyDown(KeyCode.O)) {
			freedom_state();
			myState = State.freedom;
		} else if (Input.GetKeyDown("return") && myState == State.freedom) {
			Start();
		}	
	}
	
	void cell_state () {
		text.text = "You're in a prison! \n" +
					"There is a dirty sheet on the bed, a mirror on the wall and a door.\n" +
					"When you try to open the door, you realize it's locked from the outside. \n\n" +
					"Press [S] to look at the Sheets,\n" +
					"Press [M] to watch yourself in the Mirror,\n" +
					"or press [L] to inspect the Lock.";
					
	}
	
	void mirror_state () {
		text.text = "Yikes! Who's that!? Ah, me... How long I must have been here! \n\n" +
					"Press [T] to take the mirror,\n" +
					"or press [R] to go back to roaming the cell.";
	}
	
	void lock_0_state () {
		text.text = "The lock looks pretty stable. There must be another way! \n\n" +
					"Press [R] to go back to roaming the cell.";
	}
	
	void sheets_state () {
		text.text = "The sheets look disgusting. Someone should clean up around here! \n\n" +
					"Press [R] to go back to roaming the cell.";
	}
	
	void cell_mirror_state () {
		text.text = "You can barely carry the mirror. There must a good way to use it. \n\n" +
					"Press [C] to Combine it with the lock and smash the lock.";
	}
	
	void lock_1_state () {
		text.text = "Baem! You did it. You push open the hour - sunlight floods the room! \n\n" +
					"Press [O] to fully Open the door and go into freedom,\n" +
					"or press [R] to go back to Roaming the cell.";	
	}
	
	void freedom_state () {
		text.text = "You broke free! Enjoy :) \n\n" +
					"Press [Enter] to restart the game.";
	}
}
