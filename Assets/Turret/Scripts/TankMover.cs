using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject bullet3;

    int butten = 0;
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
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            butten = 2;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            butten = 3;
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
        if (butten == 0 || butten == 1)
        {
            GameObject bulletGameObj = Instantiate(bullet1, muzzlePoint.position, muzzlePoint.rotation);
        }
        else if (butten == 2)
        {
            GameObject bulletGameObj = Instantiate(bullet2, muzzlePoint.position, muzzlePoint.rotation);
        }
        else if (butten == 3)
        {
            GameObject bulletGameObj = Instantiate(bullet3, muzzlePoint.position, muzzlePoint.rotation);
        }
    }
}
