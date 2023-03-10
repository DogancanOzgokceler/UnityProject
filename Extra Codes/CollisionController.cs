using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public float pushForce = 500f;  // Çarpıştırılan nesnenin itme gücü

    private Rigidbody rb;  // Çarpıştırılan nesnenin Rigidbody komponenti

    void Start()
    {
        // Çarpıştırılan nesnenin Rigidbody komponentini al
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpıştırılan nesnenin pozisyonu ile çarpıştığı nesnenin pozisyonu arasındaki vektörel farkı al
        Vector3 pushDirection = transform.position - collision.transform.position;
        // Bu vektörel fark üzerine kuvvet uygula
        rb.AddForce(pushDirection.normalized * pushForce);
    }
}