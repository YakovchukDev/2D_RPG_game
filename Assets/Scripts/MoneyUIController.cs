using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUIController : MonoBehaviour
{
    public static int Coins;
    public static Text TextValue;

    void Start()
    {
        Coins = 0;
        TextValue = GetComponent<Text>();
    }
}
