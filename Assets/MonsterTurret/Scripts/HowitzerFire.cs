using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowitzerFire : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Monster")
        {
            Destroy(gameObject);
        }
    }
}
