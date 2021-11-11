using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int Healing = 30;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(HealthUIController.Health < 100)
            {
                HealthUIController.Health += Healing;
                HealthUIController.TextValue.text = HealthUIController.Health.ToString();
            }
            
            Destroy(gameObject);
        }
    }
}
