using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float mass = 1f;  // Objenin kütlesi

    private Rigidbody rb;  // Objenin Rigidbody komponenti

    void Start()
    {
        // Objenin Rigidbody komponentini al
        rb = GetComponent<Rigidbody>();

        // Objenin yer çekimine gravite etkisi ekle
        rb.useGravity = true;
        rb.mass = mass;
    }
}