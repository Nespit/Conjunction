using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
	[SyncVar]public Color playerColorA;
	[SyncVar]public Color playerColorB;
	[SyncVar]public Color playerColorC;
	[SyncVar]public Color playerColorD;

	[SyncVar]public bool colorIsTakenA;
	[SyncVar]public bool colorIsTakenB;
	[SyncVar]public bool colorIsTakenC;
	[SyncVar]public bool colorIsTakenD;

	public static GameManager instance = null;

	void Awake()
	{
		//Enforce singleton pattern.
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);    
		}
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
