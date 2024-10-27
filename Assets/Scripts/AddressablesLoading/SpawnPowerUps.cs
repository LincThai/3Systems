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
        // this will be for the places i want the powerUps to be spawned
        public Transform[] spawnLocations;

        private AsyncOperationHandle<GameObject> loadPowerUpsHandle;

        // the index of the item i want to spawn which i'll randomize
        private int index;

        private void Start()
        {
            // call function to spawn all the powerups in the level
            // at set locations
            SpawnMultiPowerUps();
        }

        private void SpawnMultiPowerUps()
        {
            for (int i = 0; i < spawnLocations.Length; i++)
            {
                // randomize the powerup
                index = Random.Range(0, powerUps.Length);
                // call spawn powerup
                SpawnPowerUp(spawnLocations[i]);
            }
        }

        private async void SpawnPowerUp(Transform spawnPoint)
        {
            // spawns the powerup asynchronously
            loadPowerUpsHandle = powerUps[index].InstantiateAsync(spawnPoint);

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
