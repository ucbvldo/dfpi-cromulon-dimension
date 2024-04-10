using UnityEngine;

[ExecuteAlways]
public class Planet : MonoBehaviour
{
    [Range(0,100)]
    public float radius;
    [Range(0,100)]
    public float density;

    public Vector3 initialVelocity;
    
    public Rigidbody rb;
    
    public float Mass => MathUtils.GetMass(density, MathUtils.GetSphereVolume(radius));

    // THE SAME AS THE CODE ABOVE
    // public float Mass
    // {
    //     get
    //     {
    //         return MathUtils.GetMass(density, MathUtils.GetSphereVolume(radius));
    //     }
    // }

    // THE SAME AS THE CODE ABOVE
    // public float GetMass()
    // {
    //     return MathUtils.GetMass(density, MathUtils.GetSphereVolume(radius));
    // }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(radius, radius, radius);
        rb.mass = Mass;

    }
    
}
