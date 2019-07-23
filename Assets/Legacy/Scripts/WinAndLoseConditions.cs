using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinAndLoseConditions : MonoBehaviour {

    public bool m_startedCountdown = false;
    NodeController[] nodeControllers;
    public float timeLeft = 300.0f;

    public Text text;


    void Start()
    {
        nodeControllers = FindObjectsOfType(typeof(NodeController)) as NodeController[]; 
    }

    void Update()
    {
        if (m_startedCountdown && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            text.text = Mathf.Round(timeLeft).ToString();


            for (int i = 0; i < nodeControllers.Length; i++)
            {
                if (nodeControllers[i].m_isInfected)
                    break;
                else if (i == nodeControllers.Length - 1)
                    text.text = "<b>You win!</b>";
            }
        }

        if (m_startedCountdown && timeLeft <= 0)
        for (int i = 0; i < nodeControllers.Length; i++)
        {
            if (nodeControllers[i].m_isInfected)
                text.text = "<b>You lose</b>";
        }


    }

    public void StartCountdown()
    {
        m_startedCountdown = true;
    }
}
