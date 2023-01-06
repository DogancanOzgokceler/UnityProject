using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtarminateMe : MonoBehaviour
{
    private bool inGameZone;  // "Game Zone" içinde olup olmadýðý
    private float timeInGameZone;  // "Game Zone" içinde geçirilen süre

    private void OnTriggerEnter(Collider other)
    {
        // Eðer nesne "Game Zone" ile çarpýþtýysa, "Game Zone" içindeyiz ve
        // zaman sayacýný sýfýrla
        if (other.gameObject.CompareTag("GameZone"))
        {
            inGameZone = true;
            timeInGameZone = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Eðer nesne "Game Zone" dan çýktýysa, "Game Zone" içinde deðiliz
        if (other.gameObject.CompareTag("GameZone"))
        {
            inGameZone = false;
        }
    }

    private void Update()
    {
        // Eðer nesne "Game Zone" içinde ise, zaman sayacýný arttýr
        if (inGameZone)
        {
            timeInGameZone += Time.deltaTime;
        }

        // Eðer nesne "Game Zone" içinde deðilse ve zaman sayacý 20 saniyeyi geçti ise,
        // nesneyi yok et
        if (!inGameZone && timeInGameZone > 10f)
        {
            Destroy(gameObject);
        }
    }
}