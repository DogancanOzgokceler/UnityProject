using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{

    public float pushForce = 500f;  // Oyuncuyu itme gücü
    public float moveSpeed = 2f;  // Yapay zeka hareket hýzý
    public float changeDirectionProbability = 0.1f;  // Yön deðiþtirme olasýlýðý
    public GameObject player;  // Oyuncu nesnesi

    private Rigidbody rb;  // Yapay zeka'nýn Rigidbody komponenti
    private Vector3 direction;  // Yapay zeka'nýn hareket yönü

    void Start()
    {
        // Yapay zeka'nýn Rigidbody komponentini al
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {    
        // Oyuncu pozisyonuna doðru yön belirle
        direction = (player.transform.position - transform.position).normalized;

        // Yapay zeka'nýn yönüne göre hareket et
        rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Eðer oyuncu ile çarpýþýrsa, oyuncuyu it
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector3.up * pushForce);
        }
    }
}