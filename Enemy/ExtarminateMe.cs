using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtarminateMe : MonoBehaviour
{
    private bool inGameZone;  // "Game Zone" i�inde olup olmad���
    private float timeInGameZone;  // "Game Zone" i�inde ge�irilen s�re

    private void OnTriggerEnter(Collider other)
    {
        // E�er nesne "Game Zone" ile �arp��t�ysa, "Game Zone" i�indeyiz ve
        // zaman sayac�n� s�f�rla
        if (other.gameObject.CompareTag("GameZone"))
        {
            inGameZone = true;
            timeInGameZone = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // E�er nesne "Game Zone" dan ��kt�ysa, "Game Zone" i�inde de�iliz
        if (other.gameObject.CompareTag("GameZone"))
        {
            inGameZone = false;
        }
    }

    private void Update()
    {
        // E�er nesne "Game Zone" i�inde ise, zaman sayac�n� artt�r
        if (inGameZone)
        {
            timeInGameZone += Time.deltaTime;
        }

        // E�er nesne "Game Zone" i�inde de�ilse ve zaman sayac� 20 saniyeyi ge�ti ise,
        // nesneyi yok et
        if (!inGameZone && timeInGameZone > 10f)
        {
            Destroy(gameObject);
        }
    }
}