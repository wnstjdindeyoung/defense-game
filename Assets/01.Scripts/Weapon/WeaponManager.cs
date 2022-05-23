using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform pocket;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform player;

    [SerializeField] private GameObject bullet;

    public LayerMask enemyLayer;

    public static WeaponManager Instance;

    PlayerMove playerMove;
    //private int weaponUnitCount = 0;

    private void Awake()
    {
        Instance = this;
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }



    public void Armed(GameObject weapon)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon.transform.parent = grabPoint.transform;
            weapon.transform.position = grabPoint.transform.position;
            weapon.transform.localEulerAngles = Vector3.zero;
        }
    }

    public void Disarm(GameObject weapon)
    {
        Vector3 pocketRot = new Vector3 (0, 0, -112);

        if(Input.GetKeyDown(KeyCode.X) && weapon.transform.parent != pocket.transform)
        {
            Debug.Log("pocket");

            weapon.transform.parent = pocket.transform;
            weapon.transform.position = pocket.position;
            weapon.transform.localEulerAngles = pocketRot;
        }
    }

    public void Fire(Transform firePos, GameObject damageDealer, float damage)
    {


        RaycastHit2D hit;
        Collider2D col;

        if (Input.GetMouseButtonDown(0))
        {

            hit = Physics2D.Raycast(firePos.position, Vector2.right * 10, enemyLayer);
            Debug.DrawRay(firePos.position, Vector2.right * 10, Color.red, 0.3f);

            if (hit)
            {
                col = hit.collider;
                IDamageable iDmg = col.GetComponent<IDamageable>();
                iDmg.OnDamage(damage, damageDealer);
            }
        }
    }
}
