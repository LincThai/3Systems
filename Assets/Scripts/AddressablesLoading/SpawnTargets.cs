using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ThreeSystems.AddressableLoading
{
    public class SpawnTargets : MonoBehaviour
    {
        // this will store the object i want to spawn
        public AssetReferenceT<GameObject> target;
        // this will be for the places i want the targets to be spawned
        public Transform[] spawnLocations;

        private AsyncOperationHandle<GameObject> loadTargetHandle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // calls the function to spawn multiple targets
                TargetSpawning();
            }
        }

        private void TargetSpawning()
        {
            // spawns a target at every location in the list
            for (int i = 0; i < spawnLocations.Length; i++)
            {
                Debug.Log("Spawning");
                SpawnTarget(spawnLocations[i]);
            }
        }

        private async void SpawnTarget(Transform spawnPoint)
        {
            // spawns the targets asychronously
            loadTargetHandle = target.InstantiateAsync(spawnPoint);

            while (!loadTargetHandle.IsDone)
            {
                // the delay
                await Task.Delay(16);
            }

            if (loadTargetHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Target Spawned");
            }
        }
    }
}
