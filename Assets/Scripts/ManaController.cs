using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    public int NumberOfMana;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ManaUIController.Mana += NumberOfMana;
            ManaUIController.TextValue.text = ManaUIController.Mana.ToString();
            Destroy(gameObject);
        }
    }
}
