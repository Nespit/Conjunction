﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PreviousButton : MonoBehaviour {

	private Button button;
	private ProjectManager projectManager;

	// Use this for initialization
	void Start () {
		projectManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ProjectManager> ();
		button = GetComponent<Button> ();
		button.onClick.AddListener( () => {GoToPreviousPage();} ); 

		//If the button is not necessary disable it and enable it if it becomes necessary.
		if (projectManager.iSlideNumber == 0 && button.gameObject.activeSelf) {
			button.gameObject.SetActive (false);
		} else if (!button.gameObject.activeSelf) {
			button.gameObject.SetActive (true);
		}
	}

	void GoToPreviousPage() {
		projectManager.GoToPreviousPage ();
	}
}
