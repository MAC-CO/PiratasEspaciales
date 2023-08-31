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
    public Vector2 dispersion;
    //public float recoil;
    //public float dispersion;
    
    [HideInInspector] 
    public bool reloading;


    public float GetDispersion()
    {
        return dispersion.x;
    }
}
