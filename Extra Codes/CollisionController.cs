using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public float pushForce = 500f;  // �arp��t�r�lan nesnenin itme g�c�

    private Rigidbody rb;  // �arp��t�r�lan nesnenin Rigidbody komponenti

    void Start()
    {
        // �arp��t�r�lan nesnenin Rigidbody komponentini al
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �arp��t�r�lan nesnenin pozisyonu ile �arp��t��� nesnenin pozisyonu aras�ndaki vekt�rel fark� al
        Vector3 pushDirection = transform.position - collision.transform.position;
        // Bu vekt�rel fark �zerine kuvvet uygula
        rb.AddForce(pushDirection.normalized * pushForce);
    }
}