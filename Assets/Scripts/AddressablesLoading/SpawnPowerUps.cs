using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ThreeSystems.AddressableLoading
{
    public class SpawnPowerUps : MonoBehaviour
    {
        // the array of assets i want to spawn/load
        public AssetReferenceT<GameObject>[] powerUps;

        private AsyncOperationHandle<GameObject> loadPowerUpsHandle;

        // the index of the item i want to spawn which i'll randomize
        private int index;

        private void Start()
        {
            // randomize the powerup
            index = Random.Range(0, powerUps.Length);
        }

        private async void SpawnPowerUp()
        {
            // spawns the powerup asynchronously
            loadPowerUpsHandle = powerUps[index].InstantiateAsync();

            while (!loadPowerUpsHandle.IsDone)
            {
                // the delay
                await Task.Delay(16);
            }

            if (loadPowerUpsHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("PowerUp Spawned");

            }
        }
    }
}
