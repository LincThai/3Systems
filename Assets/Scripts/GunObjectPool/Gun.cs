using UnityEngine;
using UnityEngine.Pool;

namespace ThreeSystems.Shooting
{
    public class Gun : MonoBehaviour
    {
        // set variables
        [SerializeField] private int ammoCapacity = 10;
        [SerializeField] private int maxAmmoCount = 100;

        // spawn position
        public Transform bulletSpawn;
        // the bullet
        public Bullet bulletPrefab;

        private ObjectPool<Bullet> bulletPool;
        public ObjectPool<Bullet> BulletPool => bulletPool;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            // make and setup object pool
            bulletPool = new ObjectPool<Bullet>(() =>
            {
                // spawn bullet
                Bullet bullet = Instantiate(bulletPrefab, bulletSpawn);
                // asign to the pool
                bullet.SetPool(bulletPool);
                return bullet;
            },
            bullet =>
            {
                bullet.transform.position = bulletSpawn.position;
                bullet.transform.rotation = bulletSpawn.rotation;
                bullet.gameObject.SetActive(true);
            },
            bullet => { bullet.gameObject.SetActive(false); },
            bullet => { Destroy(bullet.gameObject); },
            false, ammoCapacity, maxAmmoCount);
        }
    }
}
