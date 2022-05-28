using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Transform firePos;

    private float currentDelayTime = 0;

    [SerializeField] private float damage = 1;
    [SerializeField] private float fireDelayTime;

    [SerializeField] private bool isWork = false;

    void Update()
    {   
        if (isWork) 
        { 
            currentDelayTime += Time.deltaTime;

            WeaponManager.Instance.Disarm(this.gameObject, () => isWork = false);
            if(Input.GetMouseButtonDown(0) && currentDelayTime >= fireDelayTime)
            {
                WeaponManager.Instance.Fire(firePos, this.gameObject, damage);

                currentDelayTime = 0;
            }
        }

        if(!isWork) 
        { 
            WeaponManager.Instance.Armed(this.gameObject, () => isWork = true);
        }
    }
}
