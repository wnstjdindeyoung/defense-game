using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotate : MonoBehaviour
{
    PlayerMove playerMove;
    Transform playerTrm;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        playerTrm = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        //마우스 방향으로 회전 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = (mousePos - transform.position);

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        //회전값 제한 
        Vector3 maxRotate = new Vector3(0, 0, 80);
        Vector3 minRotate = new Vector3(0, 0, -80);
        angle = Mathf.Clamp(angle, minRotate.z, maxRotate.z);

        Quaternion rotaion = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotaion;
    }
}
