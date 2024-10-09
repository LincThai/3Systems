using System.Collections;
using System.Collections.Generic;
using ThreeSystems.PowerUp;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{
    // set variables
    // to store a powerup scriptable object
    public PowerUp powerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Picked Up");
            Destroy(gameObject);
        }
    }
}
