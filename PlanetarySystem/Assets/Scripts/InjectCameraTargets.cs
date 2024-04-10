using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class InjectCameraTargets : MonoBehaviour
{
    public CinemachineTargetGroup targetGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void SetTargets(List<Planet> planets)
    {
        
        targetGroup.m_Targets = new CinemachineTargetGroup.Target[planets.Count];
        
        for(int i = 0; i<planets.Count; i++)
        {
            var target = new CinemachineTargetGroup.Target
            {
                target = planets[i].transform,
                radius =  planets[i].radius,
                weight =  planets[i].Mass
            };
          
            targetGroup.m_Targets[i] = target;
        }
    }
}
