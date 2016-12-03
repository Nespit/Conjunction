using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
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

    public Sprite virus;
    public Sprite cross;
    public Sprite shield;
    public Sprite sword;

    public bool isInfected;
    private bool startedSpreading = false;
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
                    connectionRendererC.SetPosition(1, connectionC.transform.position);

                    connectionRendererC.startColor = ownerColor;
                    connectionRendererC.endColor = connectionControllerC.ownerColor;
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

    void Update()
    {
        if (isInfected && !startedSpreading)
        {
            StartSpreading();
        }
    }

    public void StartSpreading()
    {
        StartCoroutine(Spread());
        startedSpreading = true;
    }

    IEnumerator Spread()
    {
        yield return new WaitForSeconds((int)Random.Range(5, 8));
        if (isInfected)
        {
            //int rnd = (int)Random.Range(1, 16);

            if (connectionA != null)
            {
                connectionControllerA = connectionA.GetComponent<NodeController>();

                if (!connectionControllerA.isInfected)
                {
                    connectionControllerA.StartInfection();          
                }
            }
            if (connectionB != null)
            {
                connectionControllerB = connectionB.GetComponent<NodeController>();

                if (!connectionControllerB.isInfected)
                {
                    connectionControllerB.StartInfection();
                }

            }
            if (connectionC != null)
            {
                connectionControllerC = connectionC.GetComponent<NodeController>();

                if (!connectionControllerC.isInfected)
                {
                    connectionControllerC.StartInfection();
                }
            }
            if (connectionD != null)
            {
                connectionControllerD = connectionD.GetComponent<NodeController>();

                if (!connectionControllerD.isInfected)
                {
                    connectionControllerD.StartInfection();
                }
            }
        }

        startedSpreading = false;
    }

    public void StartInfection()
    {
        if (!isProtected && !isInfected)
        {
            StartCoroutine(Infect());
        }
    }

    IEnumerator Infect()
    {
        if (!isProtected && !isInfected)
        {
            yield return new WaitForSeconds(0);
            isInfected = true;
            symbolRenderer.sprite = virus;
            stateColorRenderer.color = Color.red;
        }
    }

    public void StartProtecting()
    {
        if (!isProtected && !isInfected)
        {
            StartCoroutine(Protect());
            symbolRenderer.sprite = shield;
            stateColorRenderer.color = Color.yellow;
        }
    }

    IEnumerator Protect()
    {
        yield return new WaitForSeconds(timeTilProtected);
        if (!isInfected)
        {
            isProtected = true;
            symbolRenderer.sprite = shield;
            stateColorRenderer.color = Color.green;
        }
    }

    public void StartHealing()
    {
        if (isInfected)
        {
            StartCoroutine(Heal());
            symbolRenderer.sprite = cross;
            stateColorRenderer.color = Color.yellow;
        }
    }

    IEnumerator Heal()
    {
        yield return new WaitForSeconds(timeTilHealed);
        isInfected = false;
        symbolRenderer.sprite = null;
        stateColorRenderer.color = Color.white;
    }
}
