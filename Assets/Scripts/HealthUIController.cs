using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthUIController : MonoBehaviour
{
    [SerializeField]
    public static int Health;
    public static Text TextValue;

    void Start()
    {
        TextValue = GetComponent<Text>();
        Health = Convert.ToInt32(TextValue.text);
    }
}
