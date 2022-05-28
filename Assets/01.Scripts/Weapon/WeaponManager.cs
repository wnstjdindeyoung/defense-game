using System;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform pocket;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform player;
    [SerializeField] private Transform HandTrm;

    [SerializeField] private PoolableMono bullet;

    [SerializeField] private GameObject activeWeapon;

    public LayerMask enemyLayer;

    public static WeaponManager Instance;

    //private int weaponUnitCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Armed(GameObject weapon, Action GunSetting)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon.transform.parent = grabPoint.transform;
            weapon.transform.position = grabPoint.transform.position;
            weapon.transform.localEulerAngles = Vector3.zero;
            activeWeapon = weapon;
            GunSetting?.Invoke();
        }
    }

    public void Disarm(GameObject weapon, Action Unsetting)
    {
        Vector3 pocketRot = new Vector3 (0, 0, -112);

        if(Input.GetKeyDown(KeyCode.X) && weapon.transform.parent != pocket.transform)
        {
            Debug.Log("pocket");

            weapon.transform.parent = pocket.transform;
            weapon.transform.position = pocket.position;
            weapon.transform.localEulerAngles = pocketRot;
            Unsetting?.Invoke();
        }
    }

    public void Fire(Transform firePos, GameObject damageDealer, float damage)
    {
            Vector3 lookDir = HandTrm.eulerAngles;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            
            PoolManager.instance.Pop("Bullet");
    }
}
