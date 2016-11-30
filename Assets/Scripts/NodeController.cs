using UnityEngine;
using System.Collections;

public class NodeController : MonoBehaviour
{
    private SpriteRenderer stateColorRenderer;   //Renders the outer color of the node.
    private SpriteRenderer ownerColorRenderer;   //Renders the inner color of the node.
    private SpriteRenderer symbolRenderer;  //Renders the symbol of the node.

    public Color ownerColor;
    public Color stateColor;   

    public bool isInfected;
    public bool isProtected;

    public int timeTilProtected;
    public int timeTilHealed;

    void Awake()
    {
        //Get all the sprite renderers of the node.
        foreach (Transform t in transform)
        {
            if (t.name == "Outer Color")
            {
                ownerColorRenderer = t.GetComponent<SpriteRenderer>();
                ownerColorRenderer.color = ownerColor;
            }
            else if (t.name == "Inner Color")
            {
                stateColorRenderer = t.GetComponent<SpriteRenderer>();
                stateColorRenderer.color = stateColor;
            }
            else if (t.name == "Symbol")
            {
                symbolRenderer = t.GetComponent<SpriteRenderer>();
            }
        }
    }

    void StartInfection()
    {
        if (!isProtected && !isInfected)
        {
            StartCoroutine(Infect());
        }  
    }

    IEnumerator Infect()
    {
        yield return new WaitForSeconds(40);
        isInfected = true;
    }

    void StartProtecting()
    {
        StartCoroutine(Protect());
    }

    IEnumerator Protect()
    {
        yield return new WaitForSeconds(timeTilProtected);
        isProtected = true;
    }

    void StartHealing()
    {
        if (isInfected)
        {
            StartCoroutine(Heal());
        }
    }

    IEnumerator Heal()
    {
        yield return new WaitForSeconds(timeTilHealed);
        isInfected = false;
    }
}