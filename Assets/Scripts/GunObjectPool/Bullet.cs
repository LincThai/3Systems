using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace ThreeSystems.Shooting
{
    public class Bullet : MonoBehaviour
    {
        // Set variables
        // the stats/other data variables of the bullet
        public float lifetime = 240f;
        public float bulletSpeed = 3f;

        // refernce to rigidbody
        private Rigidbody rb;

        // a object pool tp reference the object pool on gun script
        // to use functions of the pool
        ObjectPool<Bullet> bulletPool;

        void Awake()
        {
            // assign reference this objects rigid body
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            // start the lifespan coroutine
            StartCoroutine(LifeSpan(lifetime));

            // call bullet move function
            BulletMove();
        }

        private void OnCollisionEnter(Collision collision)
        {
            // deactivate the bullet and return to pool if over capacity destroy
            bulletPool.Release(this);
        }
        private IEnumerator LifeSpan(float lifetime)
        {
            yield return new WaitForSeconds(lifetime);

            // deactivate the bullet and return to pool if over capacity destroy
            bulletPool.Release(this);
        }

        public void SetPool(ObjectPool<Bullet> pool)
        {
            // assign the pool
            bulletPool = pool;
        }

        public void BulletMove()
        {
            // moves the bullet forward
            rb.velocity = transform.forward * bulletSpeed;
        }
    }
}
