using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public int NumberOfCoin;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            MoneyUIController.Coins += NumberOfCoin;
            MoneyUIController.TextValue.text = MoneyUIController.Coins.ToString();
            Destroy(gameObject);
        }
    }
}
