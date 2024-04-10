using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtils 
{
    /// <summary>
    /// Gets the Volume of a perfect Sphere
    /// </summary>
    /// <param name="R">Radius of Sphere</param>
    /// <returns>Volume as float</returns>
    public static float GetSphereVolume(float R)
    {
        return 4f / 3f * Mathf.PI * R * R * R;
    }

    /// <summary>
    /// Gets the Mass of an object, given its density and volume
    /// </summary>
    /// <param name="density"></param>
    /// <param name="volume"></param>
    /// <returns></returns>
    public static float GetMass(float density, float volume)
    {
        return density * volume;
    }
}
