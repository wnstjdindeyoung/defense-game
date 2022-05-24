using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Transform firePos;

    private float currentDelay = 0;
    [SerializeField] private float fireDelay = 1;
    [SerializeField] private float damage = 1;
    [SerializeField] private bool isWork = false;

    void Update()
    {   
        if (isWork) 
        { 
            WeaponManager.Instance.Disarm(this.gameObject, () => isWork = false);
            WeaponManager.Instance.Fire(firePos, this.gameObject, damage);
        }

        if(!isWork) 
        { 
            WeaponManager.Instance.Armed(this.gameObject, () => isWork = true);
        }
    }
}
