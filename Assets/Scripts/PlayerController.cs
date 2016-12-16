using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Color playerColor;


}

//using UnityEngine.Networking;

//public class PlayerController : NetworkBehaviour
//{
//	GameManager gameManager;
//	[SyncVar] public Color playerColor;

//    void Update()
//    {
//        if (!isLocalPlayer)
//        {
//            return;
//        }
//    }

//    void OnStartLocalPlayer()
//    {
//		AssignColor ();
//    }

//	void AssignColor()
//	{
//        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

//        bool assignedColor = false;

//		while (!assignedColor) 
//		{
//			int rnd = (int)Random.Range (1, 4);

//			switch (rnd) {
//			case 1:
//				{
//					if (!gameManager.colorIsTakenA)
//					{
//						playerColor = gameManager.playerColorA;
//						gameManager.colorIsTakenA = true;
//						assignedColor = true;
//					}
//					return;
//				}
//			case 2:
//				{
//					if (!gameManager.colorIsTakenB)
//					{
//						playerColor = gameManager.playerColorB;
//						gameManager.colorIsTakenB = true;
//						assignedColor = true;
//					}
//					return;
//				}
//			case 3:
//				{
//					if (!gameManager.colorIsTakenC)
//					{
//						playerColor = gameManager.playerColorC;
//						gameManager.colorIsTakenC = true;
//						assignedColor = true;
//					}
//					return;
//				}
//			case 4:
//				{
//					if (!gameManager.colorIsTakenD)
//					{
//						playerColor = gameManager.playerColorD;
//						gameManager.colorIsTakenD = true;
//						assignedColor = true;
//					}
//					return;
//				}
//			}
//		}

//        CmdAssignedColor(playerColor);
//    }

//    [Command]
//    public void CmdAssignedColor(Color c)
//    {
//        playerColor = c;
//    }
//}