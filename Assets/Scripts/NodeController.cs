using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//[ExecuteInEditMode]
public class NodeController : MonoBehaviour
{
    [SerializeField]
    private Image stateColorRenderer;   //Renders the outer color of the node.
    [SerializeField]
    private Image ownerColorRenderer;   //Renders the inner color of the node.
    [SerializeField]
    private Image symbolRenderer;  //Renders the symbol of the node.

    [SerializeField]
    private Sprite virus;
    [SerializeField]
    private Sprite cross;
    [SerializeField]
    private Sprite shield;
    [SerializeField]
    private Sprite sword;

    private string sortingLayer = "Connections";

    [SerializeField]
    List<City> m_connections;
    Dictionary<NodeController,LineRenderer> m_connectedCities;

    public Material connectionMat;
    public Color ownerColor;
    public Color stateColor;
    
    private bool m_isInfected;
    public bool startedSpreading
    {
        get
        {
            return m_infection != null;
        }
    }
    public bool isProtected;

    private WaitForSeconds[] m_infectionTicks;
    private WaitForSeconds m_protectedDelay;
    private WaitForSeconds m_protectedTick;
    private WaitForSeconds m_healDelayTick;

    [SerializeField]
    private int m_numberOfInfectionTickers;
    [SerializeField]
    private float m_minInfectionTickTime;
    [SerializeField]
    private float m_maxInfectionTickTime;
    [SerializeField]
    private float m_protectDelay;
    [SerializeField]
    private float m_protectionDuration;
    [SerializeField]
    private float m_healDelay;

    private Coroutine m_infection;
    private Coroutine m_protection;
    private Coroutine m_heal;

    private const float CONNECTION_WIDTH = 0.17f;


    void Start()
    {
        //Initialize YIELDs
        m_infectionTicks = new WaitForSeconds[m_numberOfInfectionTickers];
        m_protectedDelay = new WaitForSeconds(m_protectDelay);
        m_protectedTick = new WaitForSeconds(m_protectionDuration);
        m_healDelayTick = new WaitForSeconds(m_healDelay);

        for (int i = 0; i < m_numberOfInfectionTickers; i++)
        {
            m_infectionTicks[i] = new WaitForSeconds(Random.Range(m_minInfectionTickTime, m_maxInfectionTickTime));
        }

        //Get connected nodes
        m_connectedCities = new Dictionary<NodeController, LineRenderer>();
        var DB = transform.parent.GetComponent<CityDatabase>();
        for (int i = 0; i < m_connections.Count; i++)
        {
            GameObject nO = new GameObject("Connection Renderer");
            nO.transform.parent = transform;
            nO.transform.localPosition = Vector3.zero;
            nO.transform.localRotation = Quaternion.identity;

            m_connectedCities.Add(DB.GetCity(m_connections[i]), nO.AddComponent<LineRenderer>());
        }

        //setup connections
        foreach (KeyValuePair<NodeController, LineRenderer> connection in m_connectedCities)
        {
            connection.Value.material = connectionMat;
            connection.Value.startWidth = CONNECTION_WIDTH;
            connection.Value.endWidth = CONNECTION_WIDTH;
            connection.Value.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            connection.Value.receiveShadows = false;
            connection.Value.sortingLayerName = sortingLayer;
            connection.Value.SetPosition(0, transform.position);
            connection.Value.SetPosition(1, connection.Key.transform.position);
            connection.Value.startColor = ownerColor;
            connection.Value.endColor = connection.Key.ownerColor;
        }
    }

    #region Infect
    public void Infect()
    {
        if (!m_isInfected && !isProtected)
        {
            m_infection = StartCoroutine(Infection());
        }

    }

    IEnumerator Infection()
    {
        m_isInfected = true;
        symbolRenderer.sprite = virus;
        stateColorRenderer.color = Color.red;
        while (m_isInfected)
        {
            //Array of waitfor seconds
            yield return m_infectionTicks[Random.Range(0, m_infectionTicks.Length)];
            var city = m_connectedCities.Keys.ElementAt(Random.Range(0,m_connectedCities.Count));
            if (!city.m_isInfected)
                city.Infect();         
            //SPREAD TO OTHERS LOGIC
        }
    }
    #endregion

    #region Protect
    public void Protect()
    {
        if (!isProtected && !m_isInfected)
            m_protection = StartCoroutine(Protection());
    }

    IEnumerator Protection()
    {
        symbolRenderer.sprite = shield;
        stateColorRenderer.color = Color.yellow;
        yield return m_protectedDelay;
        if (!m_isInfected)
        {
            isProtected = true;
            stateColorRenderer.color = Color.green;
            while (true)
            {
                yield return m_protectedTick;
                isProtected = false;
                symbolRenderer.sprite = null;
                stateColorRenderer.color = Color.white;
                break;
            }
        }  
        m_protection = null;
    }
    #endregion

    #region Cure
    public void Cure()
    {
        if (m_isInfected)
             m_heal = StartCoroutine(Healing());
    }

    IEnumerator Healing()
    {
        symbolRenderer.sprite = cross;
        stateColorRenderer.color = Color.yellow;
        yield return m_healDelayTick;
        m_isInfected = false;
        StopCoroutine(m_infection);
        m_infection = null;
        symbolRenderer.sprite = null;
        stateColorRenderer.color = Color.white;
        m_heal = null;
    }
    #endregion
}
