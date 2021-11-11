using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUIController : MonoBehaviour
{
    [SerializeField]
    public static int Mana;
    public static Text TextValue;

    void Start()
    {
        Mana = 0;
        TextValue = GetComponent<Text>();
    }
}
