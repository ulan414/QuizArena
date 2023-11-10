using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FollowPlayer : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
