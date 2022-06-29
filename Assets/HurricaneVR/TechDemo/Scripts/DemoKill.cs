using HurricaneVR.Framework.Core.Stabbing;
using HurricaneVR.TechDemo.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DemoKill : MonoBehaviour
{
    public int RequiredStabCounts = 5;
    int _stabCounts = 0;
    bool _killed = false;

    public UnityEvent KillEvent;
    void Start()
    {
        foreach(HVRStabbable stab in GetComponentsInChildren<HVRStabbable>())
        {
            stab.Stabbed.AddListener(OnStabbed);
        }
    }

    void OnStabbed(StabArgs args)
    {
        Vector3 position = args.Point;
#if UNITY_EDITOR
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(position, 1);
#endif
        
        if(_stabCounts++ >= RequiredStabCounts)
        {
            _killed = true;
            Die();
        }
    }

    void Die()
    {
        foreach (DemoFullStabConfetti confetti in GetComponentsInChildren<DemoFullStabConfetti>())
        {
            confetti.PopKillConfetti();
        }
        foreach (ConfigurableJoint joint in GetComponentsInChildren<ConfigurableJoint>())
        {
            Destroy(joint, 1.0f);
        }
        KillEvent.Invoke();
    }

}
