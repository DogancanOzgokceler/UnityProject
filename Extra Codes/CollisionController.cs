using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public float pushForce = 500f;  // Çarpýþtýrýlan nesnenin itme gücü

    private Rigidbody rb;  // Çarpýþtýrýlan nesnenin Rigidbody komponenti

    void Start()
    {
        // Çarpýþtýrýlan nesnenin Rigidbody komponentini al
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþtýrýlan nesnenin pozisyonu ile çarpýþtýðý nesnenin pozisyonu arasýndaki vektörel farký al
        Vector3 pushDirection = transform.position - collision.transform.position;
        // Bu vektörel fark üzerine kuvvet uygula
        rb.AddForce(pushDirection.normalized * pushForce);
    }
}