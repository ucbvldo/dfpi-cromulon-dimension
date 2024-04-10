using UnityEngine;
using UnityEngine.VFX.Utility;

[AddComponentMenu("VFX/Property Binders/Simple Values/Vector3 Binder")]
[VFXBinder("Simple Values/Vector3")]
public class Vector3VFXBinder : ValueBinderBase<Vector3>
{
    [VFXPropertyBinding(nameof(UnityEngine.Vector3)),
     SerializeField,
     UnityEngine.Serialization.FormerlySerializedAs("m_Parameter")]
    protected ExposedProperty m_Property = "Some Vector3";

    protected override ExposedProperty Property => m_Property;
}
