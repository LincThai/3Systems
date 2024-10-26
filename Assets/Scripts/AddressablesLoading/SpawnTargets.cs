using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.VFX;

namespace ThreeSystems.AddressableLoading
{
    public class SpawnTargets : MonoBehaviour
    {
        // this will store the object i want to spawn
        public AssetReferenceT<GameObject> target;

        private AsyncOperationHandle<GameObject> loadTargetHandle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // calls the spawn target function
                SpawnTarget();
            }
        }

        private async void SpawnTarget()
        {
            // spawns the targets asychronously
            loadTargetHandle = target.InstantiateAsync();


        }
    }
}
