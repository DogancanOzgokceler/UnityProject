using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{

    public float pushForce = 500f;  // Oyuncuyu itme g�c�
    public float moveSpeed = 2f;  // Yapay zeka hareket h�z�
    public float changeDirectionProbability = 0.1f;  // Y�n de�i�tirme olas�l���
    public GameObject player;  // Oyuncu nesnesi

    private Rigidbody rb;  // Yapay zeka'n�n Rigidbody komponenti
    private Vector3 direction;  // Yapay zeka'n�n hareket y�n�

    void Start()
    {
        // Yapay zeka'n�n Rigidbody komponentini al
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {    
        // Oyuncu pozisyonuna do�ru y�n belirle
        direction = (player.transform.position - transform.position).normalized;

        // Yapay zeka'n�n y�n�ne g�re hareket et
        rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // E�er oyuncu ile �arp���rsa, oyuncuyu it
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector3.up * pushForce);
        }
    }
}