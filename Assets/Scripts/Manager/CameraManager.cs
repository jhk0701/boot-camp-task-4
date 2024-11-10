using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    public CinemachineVirtualCamera virtualCamera;

    public void SetTarget(Transform target)
    {
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
    }
    
}
