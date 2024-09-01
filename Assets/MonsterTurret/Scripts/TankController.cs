using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject turret;
    [SerializeField] float turretSpeed;
    public float rotturret;
    public int butten = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rotturret = Input.GetAxisRaw("lrarrow");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);
        turret.transform.Rotate(Vector3.up * rotturret * turretSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            butten = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            butten = 2;
        }
        
    }
    private void Fire()
    {
        if (butten == 0 || butten == 1)
        {
            Instantiate(bullet1, muzzlePoint.position, muzzlePoint.rotation);
        }
        else if (butten == 2)
        {
            Instantiate(bullet2, muzzlePoint.position, muzzlePoint.rotation);
        }
    }
}
