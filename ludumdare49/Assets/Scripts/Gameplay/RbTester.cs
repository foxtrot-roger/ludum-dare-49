using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbTester : MonoBehaviour
{
    private Rigidbody2D rb;
    public InputConfiguration Input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.ReadJump())
            rb.velocity += Vector2.up * 0.5f;
    }
}
