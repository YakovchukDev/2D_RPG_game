using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    [SerializeField]
    public static int Health;
    public static Text TextValue;

    void Start()
    {
        Health = 70;
        TextValue = GetComponent<Text>();
    }
}
