using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class NodeController : MonoBehaviour
{
    private SpriteRenderer stateColorRenderer;   //Renders the outer color of the node.
    private SpriteRenderer ownerColorRenderer;   //Renders the inner color of the node.
    private SpriteRenderer symbolRenderer;  //Renders the symbol of the node.

    private LineRenderer connectionRendererA;
    private LineRenderer connectionRendererB;
    private LineRenderer connectionRendererC;
    private LineRenderer connectionRendererD;

    private NodeController connectionControllerA;
    private NodeController connectionControllerB;
    private NodeController connectionControllerC;
    private NodeController connectionControllerD;

    private string sortingLayer = "Connections";

    public GameObject connectionA;
    public GameObject connectionB;
    public GameObject connectionC;
    public GameObject connectionD;

    public Color ownerColor;
    public Color stateColor;

    public bool isInfected;
    public bool isProtected;

    public int timeTilProtected;
    public int timeTilHealed;

    void Awake()
    {
        //Get all the renderers attached to the children of the node.
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
            else if (t.name == "ConnectionA")
            {
                connectionRendererA = t.GetComponent<LineRenderer>();
                connectionRendererA.sortingLayerName = sortingLayer;

                //Set the connection properties for this connection.
                if (connectionA != null)
                {
                    connectionControllerA = connectionA.GetComponent<NodeController>();

                    connectionRendererA.SetPosition(0, transform.position);
                    connectionRendererA.SetPosition(1, connectionA.transform.position);

                    connectionRendererA.startColor = ownerColor;
                    connectionRendererA.endColor = connectionControllerA.ownerColor;
                }
            }
            else if (t.name == "ConnectionB")
            {
                connectionRendererB = t.GetComponent<LineRenderer>();
                connectionRendererB.sortingLayerName = sortingLayer;

                //Set the connection properties for this connection.
                if (connectionB != null)
                {
                    connectionControllerB = connectionB.GetComponent<NodeController>();

                    connectionRendererB.SetPosition(0, transform.position);
                    connectionRendererB.SetPosition(1, connectionB.transform.position);

                    connectionRendererB.startColor = ownerColor;
                    connectionRendererB.endColor = connectionControllerB.ownerColor;
                }
            }
            else if (t.name == "ConnectionC")
            {
                connectionRendererC = t.GetComponent<LineRenderer>();
                connectionRendererC.sortingLayerName = sortingLayer;

                //Set the connection properties for this connection.
                if (connectionC != null)
                {
                    connectionControllerC = connectionC.GetComponent<NodeController>();

                    connectionRendererC.SetPosition(0, transform.position);
                    connectionRendererC.SetPosition(1, connectionA.transform.position);

                    connectionRendererC.startColor = ownerColor;
                    connectionRendererC.endColor = connectionControllerA.ownerColor;
                }
            }
            else if (t.name == "ConnectionD")
            {
                connectionRendererD = t.GetComponent<LineRenderer>();
                connectionRendererD.sortingLayerName = sortingLayer;

                //Set the connection properties for this connection.
                if (connectionD != null)
                {
                    connectionControllerD = connectionD.GetComponent<NodeController>();

                    connectionRendererD.SetPosition(0, transform.position);
                    connectionRendererD.SetPosition(1, connectionD.transform.position);

                    connectionRendererD.startColor = ownerColor;
                    connectionRendererD.endColor = connectionControllerD.ownerColor;
                }
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
