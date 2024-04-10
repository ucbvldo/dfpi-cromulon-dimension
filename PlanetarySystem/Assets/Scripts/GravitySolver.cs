using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySolver : MonoBehaviour
{
    
    public float G = 6.67430e-11f; // Gravitational constant in m^3 kg^-1 s^-2

    public bool run;
    
    public PlanetGeneration planetGen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!run)
            return;
        
        var planets = planetGen.planets;

        for (int i = 0; i < planets.Count; i++)
        {
            var targetBody = planets[i].rb;
            
            for (int j = 0; j < planets.Count; j++)
            {
                var body = planets[j].rb;
                
                if (body != targetBody) 
                {
                    var direction = body.position - targetBody.position;
                    var distance = direction.magnitude;

                    // Prevent division by zero if distance is too small
                    if (distance > 0) 
                    {
                        var forceMagnitude = GravitationalPull( G,targetBody.mass, body.mass , distance);
                        var force = direction.normalized * forceMagnitude;
                        targetBody.AddForce(force, ForceMode.Force);
                    }
                }
            }
        }
    }

    public static float GravitationalPull(float G, float mass1, float mass2, float distance)
    {
        return G * mass1 * mass2 / (distance * distance);
    }
}
