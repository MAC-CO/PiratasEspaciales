using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunData _gunData;
    [SerializeField] Transform _muzzle;

    public ParticleSystem flash;

    private float timeSinceLastShot;

    private Vector3 positionImpacto;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReloading;

        _gunData.ResetStats();

        _gunData.currentAmmo = _gunData.magSize;
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
        if (_gunData.currentAmmo > 0 && CanShoot())
        {
            _gunData.RecalcularDisparo();

            float angle = Random.Range(0, 2 * Mathf.PI);
            float radius = Random.Range(0, _gunData.GetDispersion());

            float a = radius * Mathf.Sin(angle);
            float b = radius * Mathf.Cos(angle);

            Vector3 offset = new Vector3(a,b,0);

            offset = _muzzle.rotation * offset;
            
            flash.Play();

            if (Physics.Raycast(Camera.main.transform.position + offset, Camera.main.transform.forward, out RaycastHit hitInfo, _gunData.maxDistance))
            {
                //Vector3 direction = new Vector3(0,0,0);

                Vector3 direction = (hitInfo.point - _muzzle.position).normalized;

                if (Physics.Raycast(_muzzle.position, direction, out RaycastHit Infohit))
                {
                    positionImpacto = hitInfo.point;
                    IDamagable damagable = hitInfo.transform.GetComponent<IDamagable>();
                    damagable?.Damage(_gunData.damage);
                }
            }

            _gunData.currentAmmo--;
            timeSinceLastShot = 0;
            OnGunShot();
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        _gunData.RecalcularDispersion();
        Debug.DrawRay(_muzzle.position, _muzzle.forward * _gunData.maxDistance);
    }

    private void OnGunShot()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(positionImpacto, 0.150f);
        Debug.Log("GeneroBola");
    }
}
