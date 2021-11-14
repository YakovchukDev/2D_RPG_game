using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int Healing;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(Healing > 0 && other.gameObject.tag == "Player")
        {
            if(HealthUIController.Health < 100)
            {
                HealthUIController.Health += Healing;
                HealthUIController.TextValue.text = HealthUIController.Health.ToString();
                Destroy(gameObject);
            }
            
        }
        else if(Healing < 0 && other.gameObject.tag == "Player")
        {
            if(HealthUIController.Health - Healing > 0)
            {
                HealthUIController.Health += Healing;
                HealthUIController.TextValue.text = HealthUIController.Health.ToString();
                Destroy(gameObject);
            }
            else
            {
                HealthUIController.Health = 0;
                HealthUIController.TextValue.text = HealthUIController.Health.ToString();
                Destroy(gameObject);
            }
        }
    }
}
