using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoRiseButton : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ShowButton()
    {
        if (animator != null) animator.Play("ShowButton");
    }
}
