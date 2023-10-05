using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody[] rigidbodies;
    public Collider[] colliders;

    void Start()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
    }

    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;

        }

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = enabled;
        }

        animator.enabled = !enabled;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetEnabled(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        { 
            SetEnabled(false); 
        }
    }

}
