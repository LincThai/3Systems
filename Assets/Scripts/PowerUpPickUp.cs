using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeSystems.PowerUp
{
    public class PowerUpPickUp : MonoBehaviour
    {
        // set variables
        // to store a powerup scriptable object
        public PowerUp powerUp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Picked Up");
                ApplyPowerUp();
                Destroy(gameObject);
            }
        }

        private void ApplyPowerUp()
        {
            if (powerUp.ActiveEffect == PowerUp.Effects.MoveSpeed)
            {

            }
            if (powerUp.ActiveEffect == PowerUp.Effects.JumpHeight)
            {

            }
        }
    }
}
