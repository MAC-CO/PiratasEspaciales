using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")] 
    public new string name;

    [Header("Shooting")] 
    public int damage;
    public float maxDistance;

    [Header("Shooting")] 
    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;

    //[HideInInspector] 
    public bool reloading = false;

    public Vector2 dispersion;
    public float speedDispersion;


    //[HideInInspector]
    public float actualDispersion;

    //[HideInInspector]
    public float increaseDispersion;

    [Range(0,1f)]
    public float viewActualDispersion;


    //[Header("Animations")]
    //public AnimationClip ReloadAnim;
    //public AnimationClip ShootAnim;
    

    public float GetDispersion()
    {
        return actualDispersion;
    }

    public void RecalcularDisparo()
    {
        actualDispersion = Mathf.Clamp(actualDispersion + increaseDispersion, dispersion.x, dispersion.y);
        Debug.LogError("recalculado");
    }

    public void RecalcularDispersion()
    {
        actualDispersion = Mathf.Clamp(actualDispersion - increaseDispersion * Time.deltaTime, dispersion.x, dispersion.y);

        viewActualDispersion = (actualDispersion-dispersion.x)/(dispersion.y-dispersion.x);
    }

    public void ResetStats()
    {
        actualDispersion = 0;
        currentAmmo = magSize;
        reloading = false;
    }
}
