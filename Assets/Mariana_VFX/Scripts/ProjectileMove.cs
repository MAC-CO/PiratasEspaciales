using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour {

	private float speed = 1f;
	[SerializeField] GunData _gunData; //maxdistance - firerate

    void Update()
    {

        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }

    public void Spawn(){

	}

	public void Despawn(){

	}

}





