using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int health = 100;
    
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
