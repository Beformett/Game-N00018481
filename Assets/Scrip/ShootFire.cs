using System;
using UnityEngine;

public class ShootFire : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = 10f;
    }
}