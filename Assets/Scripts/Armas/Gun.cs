using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunData _gunData;
    [SerializeField] Transform _muzzle;

    public string eventoFMOD; 

    public LayerMask CapaDano;

    public CallPartes callparte;

    public ParticleSystem flash;

    private float timeSinceLastShot;

    private Vector3 positionImpacto;

    private void Start()
    {
        Dmov2.shootInput += Shoot;
        Dmov2.reloadInput += StartReloading;

        _gunData.ResetStats();

        if(DispersionUI.Instance != null)
        {
            DispersionUI.Instance.gunData = _gunData;
        }
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
            float angle = Random.Range(0, 2 * Mathf.PI);
            float radius = Random.Range(0, _gunData.GetDispersion());

            float a = radius * Mathf.Sin(angle);
            float b = radius * Mathf.Cos(angle);

            Vector3 offset = new Vector3(a,b,0);

            offset = _muzzle.rotation * offset;
            
            flash.Play();

            if (Physics.Raycast(Camera.main.transform.position + offset, Camera.main.transform.forward, out RaycastHit hitInfo, _gunData.maxDistance))
            {
                Vector3 direction = (hitInfo.point - _muzzle.position).normalized;

                if (Physics.Raycast(_muzzle.position, direction, out RaycastHit Infohit,1000,CapaDano))
                {
                    positionImpacto = hitInfo.point;
                    IDamagable damagable = hitInfo.transform.GetComponent<IDamagable>();
                    damagable?.Damage(_gunData.damage*callparte.factor);
                }
            }

            _gunData.currentAmmo--;
            _gunData.RecalcularDisparo();
            timeSinceLastShot = 0;
            OnGunShot();
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        _gunData.RecalcularDispersion();
        //Debug.DrawRay(_muzzle.position, _muzzle.forward * _gunData.maxDistance);
    }

    private void OnGunShot()
    {
        Eventos.singleton.PlayEvento("event:/" + eventoFMOD); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(positionImpacto, 0.150f);
        Debug.Log("GeneroBola");
    }
}
