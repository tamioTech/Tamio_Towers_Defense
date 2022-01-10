using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Enemy_Mover>().transform;    
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        transform.LookAt(target);
    }

}
