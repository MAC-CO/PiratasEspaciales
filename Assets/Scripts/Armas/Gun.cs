using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunData _gunData;
    [SerializeField] Transform _muzzle;

    private float timeSinceLastShot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReloading;
    }

    public void StartReloading()
    {
        if (!_gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        _gunData.reloading = true;
        yield return new WaitForSeconds(_gunData.reloadTime);

        _gunData.currentAmmo = _gunData.magSize;
        _gunData.reloading = false;
    }

    private bool CanShoot() => !_gunData.reloading && timeSinceLastShot > 1f / (_gunData.fireRate / 60f);
    
    private void Shoot()
    {
        if (_gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(_muzzle.position, _muzzle.forward, out RaycastHit hitInfo, _gunData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                    IDamagable damagable = hitInfo.transform.GetComponent<IDamagable>();
                    damagable?.Damage(_gunData.damage);
                }

                _gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();

            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(_muzzle.position, _muzzle.forward);
    }

    private void OnGunShot()
    {
        
    }
}
