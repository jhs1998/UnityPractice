using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretController : MonoBehaviour
{
    [SerializeField] GameObject turretpoint;
    [SerializeField] GameObject turret;
    [SerializeField] float turretSpeed;
    public float rotturret;

    private void Update()
    {
        TurretMover();
    }

    private void TurretMover()
    {
        rotturret = Input.GetAxisRaw("duarrow");
        turret.transform.Rotate(Vector3.right * rotturret * turretSpeed);
    }
}
