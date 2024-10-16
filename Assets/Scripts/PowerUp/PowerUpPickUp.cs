using System.Collections;
using System.Collections.Generic;
using ThreeSystems.Player;
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
                // call the application function then destroy this onject
                ApplyPowerUp(other.GetComponent<PlayerController>());
                Destroy(gameObject);
            }
        }

        private void ApplyPowerUp(PlayerController player)
        {
            switch (powerUp.ActiveEffect)
            {
                case PowerUp.Effects.None:
                    break;
                case PowerUp.Effects.MoveSpeed:
                    player.powerUpSpeed = powerUp.increaseAmount;
                    StartCoroutine(player.PowerupDuration(powerUp.duration));
                    break;
                case PowerUp.Effects.JumpHeight:
                    player.powerUpJump = powerUp.increaseAmount;
                    StartCoroutine(player.PowerupDuration(powerUp.duration));
                    break;
            }
        }
    }
}
