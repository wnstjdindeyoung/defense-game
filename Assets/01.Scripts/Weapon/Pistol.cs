using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Transform firePos;

    private float currentDelay = 0;
    [SerializeField] float fireDelay = 1;
    [SerializeField] float damage = 1;

    void Start()
    {
        
    }

    void Update()
    {
        WeaponManager.Instance.Disarm(this.gameObject);
        WeaponManager.Instance.Armed(this.gameObject);
        WeaponManager.Instance.Fire(firePos, this.gameObject, damage);
    }
}
