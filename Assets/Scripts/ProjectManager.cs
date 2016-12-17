using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ProjectManager : MonoBehaviour {

	public static ProjectManager instance = null;
	public bool bSceneHasBeenLoaded = true;
    public int availableActions = 4;
	public int iSlideNumber;	//This integer changes according to the currently opened scene.

	void Awake()
	{
		//Enforce singleton pattern.
		if (instance == null) {
			instance = this;
			iSlideNumber = SceneManager.GetActiveScene ().buildIndex;	//Detect the currently opened scene and assign the appropriate value to our variable.
		} else if (instance != this) {
			Destroy(gameObject);    
			}
			DontDestroyOnLoad(gameObject);
		}

	void Update() {
		//Load the current scene if it hasn't been loaded yet.
		if (!bSceneHasBeenLoaded) {
			switch (iSlideNumber) {
			case 0:
				{
					bSceneHasBeenLoaded = true;
					SceneManager.LoadScene (0);
                    availableActions = 4;
                    return;
				}
			case 1:
				{
					bSceneHasBeenLoaded = true;
					SceneManager.LoadScene (1);
                    availableActions = 4;
                    return;
				}
			case 2:
				{
					bSceneHasBeenLoaded = true;
					SceneManager.LoadScene (2);
                    availableActions = 4;
                    return;
				}
            case 3:
                {
                    bSceneHasBeenLoaded = true;
                    SceneManager.LoadScene(3);
                    availableActions = 4;
                    return;
                }
            case 4:
                {
                    bSceneHasBeenLoaded = true;
                    SceneManager.LoadScene(4);
                    availableActions = 4;
                    return;
                }
            }
		}
	}

	//Function to load the next scene (in cooperation with the Update()).
	public void GoToNextPage() {
		iSlideNumber++;
		bSceneHasBeenLoaded = false;
		if (iSlideNumber > 4) 
		{
			iSlideNumber = 4;
			bSceneHasBeenLoaded = true;
		}
	}

	//Function to load the previous scene (in cooperation with the Update()).
	public void GoToPreviousPage() {	
		iSlideNumber--;
		bSceneHasBeenLoaded = false;
		if (iSlideNumber < 0) 
		{
			iSlideNumber = 0;
			bSceneHasBeenLoaded = true;
		}
	}
}
