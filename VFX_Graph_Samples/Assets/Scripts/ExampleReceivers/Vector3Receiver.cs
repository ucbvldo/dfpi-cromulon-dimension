using UnityEngine;

public class Vector3Receiver : MonoBehaviour, IValue<Vector3>
{
    [SerializeField]
    private Vector3 value;

    public Vector3 Value
    {
        get => value;
        set => this.value = value;
    }

    public float X
    {
        get => value.x;
        set => this.value.x = value;
    }
    
    public float Y
    {
        get => value.y;
        set => this.value.y = value;
    }
    
    public float Z
    {
        get => value.z;
        set => this.value.z = value;
    }
}
