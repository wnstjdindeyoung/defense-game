using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotate : MonoBehaviour
{
    Transform playerTrm;
    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        //���콺 �������� ȸ�� 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = (mousePos - transform.position);

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        if(playerMove.lookLeft == true)
        {
            angle = Mathf.Atan2(lookDir.y, -lookDir.x) * Mathf.Rad2Deg;
        }   

        //ȸ���� ���� 
        Vector3 maxRotate = new Vector3(0, 0, 80);
        Vector3 minRotate = new Vector3(0, 0, -80);
        angle = Mathf.Clamp(angle, minRotate.z, maxRotate.z);

        Quaternion rotaion = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.localRotation = rotaion;
    }
}
