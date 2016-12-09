using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum City
{
    None = 0,
    Anchorage = 1,
    Toronto = 2,
    Chicago = 3,
    SanFrancisco = 4,
    Vancouver = 5,
    Houston = 6,
    NewYork = 7,
    SaintJohn = 8,
    LosAngeles = 9,
    Jacksonville = 10,
    Miami = 11,
    MexicoCity = 12,
    Bogota = 13,
    Caracas = 14,
    Quito = 15,
    Lima = 16,
    LaPaz = 17,
    SantiagodeChile = 18,
    BuenosAires = 19,
    SaoPaulo = 20,
    RiodeJaneiro = 21,
    Brasilia = 22,
    Fortaleza = 23,
    CityCount = 24
}

public class CityDatabase : MonoBehaviour {

    private Dictionary<City, GameObject> m_cities;

	// Use this for initialization
	void Awake () {
        m_cities = new Dictionary<City, GameObject>();
        for(int i=0; i< transform.childCount; i++)
        {
            for(int j=1; j < (int)City.CityCount; j++)
            {
                if (transform.GetChild(i).name == ((City)j).ToString())
                    m_cities.Add((City)j, transform.GetChild(i).gameObject);
            }
        }

        //Debug.Log(m_cities[City.Anchorage]);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public NodeController GetCity(City city)
    {
        GameObject c = null;
        m_cities.TryGetValue(city, out c);
        return c.GetComponent<NodeController>() ;
    }
}
