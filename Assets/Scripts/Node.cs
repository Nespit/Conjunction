using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {

	//reference to gamemanager
	public int curPlayer;

	public float defaultTimerLength = 1;
	float timeLimit;
	bool timerOn;

	public enum NodeState {CLEAN, REINFORCED, INVADED, INFECTED};
	public enum NodeChangeState {INACTIVE, REINFORCING, INVASION, CLEANING};
	public NodeState curNodeState;
	public NodeChangeState curNodeChangeState;

	public GameObject contextMenu;

	public Text debugText;

	void Start () {
		
	}

	void startTimer(float howLong){
		timeLimit = Time.time + howLong;
		timerOn = true;
	}

	public void triggerReinforce(){
		curNodeChangeState = NodeChangeState.REINFORCING;
		startTimer (defaultTimerLength);
	}

	public void triggerInvade(){
		curNodeChangeState = NodeChangeState.INVASION;
		startTimer (defaultTimerLength);
	}

	public void triggerClean(){
		curNodeChangeState = NodeChangeState.CLEANING;
		startTimer (defaultTimerLength);
	}
	
	void Update () {

		if (timerOn) {
			if (Time.time >= timeLimit) {
				
				timerOn = false;
				switch (curNodeChangeState) {
				case NodeChangeState.REINFORCING:
					doReinforce ();
					break;
				case NodeChangeState.INVASION:
					doInvade ();
					break;
				case NodeChangeState.CLEANING:
					doClean (); 
					break;
				}
			} else {
				debugText.text = "" + (int)(timeLimit - Time.time);
			}
		} 
	}

	void doReinforce(){
		curNodeState = NodeState.REINFORCED;
		debugText.text = "REINFORCED";
	}

	void doInvade(){
		//cancel the action of the player
		curNodeState = NodeState.INVADED;
		debugText.text = "INVADED";
	}

	void doClean(){
		curNodeState = NodeState.CLEAN;
		debugText.text = "CLEAN";
	}

	void infectNode(){
		cancelAction ();
		curNodeState = NodeState.INFECTED;
	}

	void cancelAction(){
		timerOn = false;
		curNodeChangeState = NodeChangeState.INACTIVE;
	}


	public void displayContextMenu (){
		if (contextMenu.activeSelf)
			contextMenu.SetActive (false);
		else
			contextMenu.SetActive (true);
		//enable or disable things based on what is available
	}
		

}
