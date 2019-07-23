using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
	public Color playerColorA;
	public Color playerColorB;
	public Color playerColorC;
	public Color playerColorD;

	public bool colorIsTakenA;
	public bool colorIsTakenB;
	public bool colorIsTakenC;
	public bool colorIsTakenD;

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
}
