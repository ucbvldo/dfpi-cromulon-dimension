using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlanetGeneration : MonoBehaviour
{
    [Header("References")]
    public GameObject prefab;
    public BoxCollider bounds;

    [Header("Planet/Radius")]
    [Range(0,100)]
    public float minRadius;

    [Range(0,100)]
    public float maxRadius;
    
    [Header("Planet/Density")]
    [Range(0,100)]
    public float minDensity;

    [Range(0,100)]
    public float maxDensity;

    public List<Planet> planets;

    public UnityEvent<List<Planet>> OnPlanetAdded;
    
    // Start is called before the first frame update
    void Start()
    {
        planets = new List<Planet>();
        
        foreach (Transform child in transform)
        {
            var planet = child.GetComponent<Planet>();
            if (planet != null)
                planets.Add(planet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GenerateRandom();
    }

    public void GenerateRandom()
    {
        if (prefab == null)
            return;
        
        var min = bounds.bounds.min;
        var max = bounds.bounds.max;

        var x = Random.Range(min.x, max.x);
        var y = Random.Range(min.y, max.y);
        var z = Random.Range(min.z, max.z);
        var r = Random.Range(minRadius, maxRadius);
        var d = Random.Range(minDensity, maxDensity);
        
        var pos = new Vector3(x, y, z);

        var go = Instantiate(prefab, pos, quaternion.identity, transform);
        var planet = go.GetComponent<Planet>();
        planet.radius = r;
        planet.density = d;
        
        planets.Add(planet);
        
        OnPlanetAdded.Invoke(planets);
    }
}
