using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour 
{
	private ProjectManager projectManager;
	private Text txt;
	public Text subTxt;
    public Text availableActions;
	private int iSlideNumber;
	public bool bTextHasBeenLoaded;

	void Start () 
	{
		txt = GetComponent<Text>();
		projectManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ProjectManager> ();
	}

	void Update ()
	{
		if (!projectManager.bSceneHasBeenLoaded) {
			bTextHasBeenLoaded = false;
		}

		if (!bTextHasBeenLoaded) {
			bTextHasBeenLoaded = true;
			switch (projectManager.iSlideNumber) {
			case 0:
				{
                        txt.text = ("<b>Welcome to the virus containment training, Commander!</b>" +
                                "\n\nBefore you can start to defend the cities of our glorious conglomerate and expand our zone of influence, you have to learn what you're dealing with." + 
                                "\n\nPlease click the 'Next' button below to continue.");
					subTxt.text = ("1/5");
                    availableActions.text = ("");
                    return;
				}
			case 1:
				{
                       txt.text = ("The threat you're dealing with is a sophisticated computer virus, targeting the infrastructure of all the major cities in the world." +
                            "\n\nOnce you press the 'Release Virus' button below, two cities on the left will become infected. You can then observe how the virus spreads." +
                            "\n\nDon't worry. This is only a simulation." +
                            "\n\nClick 'Next' once you're ready to continue.");
                    availableActions.text = ("");
                    subTxt.text = ("2/5");
                    return;
				}
			case 2:
				{
					txt.text = ("Now it's time to learn how to stop the virus from spreading." +
                            "\n\nYou can either protect uninfected nodes by clicking on them or heal infected ones, also by clicking on them." +
                            "\n\nProtected nodes can't be infected by the virus. However, the protection wears off after a while, so remember to refresh it if necessary." + 
                            "\n\nNotice that both these interactions are processes and take a while to complete. Until completed, the respective nodes stay infectious and vulnerable." +
                            "\n\nAdditionally, there are limitations to how many of these processes can be run simultaneously. The number in the left bottom corner indicates how many more actions you can take." +
                            "\n\nRelease the virus as you did before and put this information to use. Don't be scared, you can't break anything.");
					subTxt.text = ("3/5");
                    return;
				}
            case 3:
                {
					txt.text = ("Unfortunately, we have not yet succeeded in seizing controll of the entire world and there are still some competitors left (notice the differently colored nodes)." +
                            "\n\nThe virus might actually help us to change that. Under normal circumstances we couldn't just take over cities. However, infected tiles are weakened and easily annexed. The only problem is, that we don't know first hand which of their cities are infected." +
                            "\n\nVirus spread has been frozen for now. Try to infiltrate the infected cities. A click on an opponents city starts the invasion attempt.");
                        subTxt.text = ("4/5");
                    return;
                    }
            case 4:
                {
                    txt.text = ("In this last scenario you'll have to put all your knowledge to use in order to stop the epidemic in time. This is meant to hone your freshly acquired skills. After unleashing the virus you'll have 5 minutes to cleanse the Americas." +
                            "\n\nGood luck Commander!");
                    subTxt.text = ("5/5");
                    return;
                    }
            }
		}

        if(projectManager.iSlideNumber > 1)
            availableActions.text = projectManager.availableActions.ToString();
	}
}
