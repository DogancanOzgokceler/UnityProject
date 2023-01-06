using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Oyuncunun hareket hýzý

    public float pushForce = 500f;  // Oyuncuyu itme gücü

    private Rigidbody rb;  // Oyuncunun Rigidbody komponenti

    void Start()
    {
        // Oyuncunun Rigidbody komponentini al
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Dokunmatik ekranda basýlan yönü al
        Vector3 touchDirection = GetTouchDirection();

        // Eðer dokunmatik ekranda bir yön belirlendi, oyuncuyu o yöne doðru hareket ettir
        if (touchDirection != Vector3.zero)
        {
            rb.velocity = new Vector3(touchDirection.x * moveSpeed, 0, touchDirection.z * moveSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Eðer Enemy ile çarpýþýrsa, oyuncuyu it
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncunun çarpýþtýðý Enemy nesnesinin pozisyonu ile oyuncunun pozisyonu arasýndaki vektörel farký al
            Vector3 pushDirection = transform.position - collision.transform.position;
            // Bu vektörel fark üzerine kuvvet uygula
            rb.AddForce(pushDirection.normalized * pushForce);
        }
    }

    private Vector3 GetTouchDirection()
    {
        // Dokunmatik ekranda basýlan yönü al
        Vector3 touchDirection = Vector3.zero;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 0);
            touchDirection = touchPosition - Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, Camera.main.nearClipPlane));
            touchDirection = touchDirection.normalized;
        }
        return touchDirection;
    }
}