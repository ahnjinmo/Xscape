using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMission
{
    public enum MissionState
    {
        TODO, STARTED, SUCCESS, FAIL
    }
    public void OnCompleted(bool isSuccess);
    public void OnInitialize();
}
