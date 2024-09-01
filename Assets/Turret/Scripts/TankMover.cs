using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ObjectPool bullet1;
    [SerializeField] ObjectPool bullet2;
    [SerializeField] ObjectPool bullet3;

    public int butten = 1;
    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            butten = 1;
            Debug.Log("Åº º¯°æ: Åº 1");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            butten = 2;
            Debug.Log("Åº º¯°æ: Åº 2");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            butten = 3;
            Debug.Log("Åº º¯°æ: Åº 3");
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);
    }

    private void Fire()
    {
        Debug.Log("¹ß»ç ½Ãµµ: Åº " + butten);

        if (butten == 1)
        {
            bullet1.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        }
        else if (butten == 2)
        {
            bullet2.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        }
        else if (butten == 3)
        {
            bullet3.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        }
    }
}
