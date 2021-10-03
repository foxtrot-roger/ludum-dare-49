using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public static ShakeCamera Instance;

    public Animator Animator;

    private void Start()
    {
        Instance = this;
    }

    public void Shake()
    {
        Animator.SetTrigger("shake");
    }
}
