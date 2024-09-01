using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] PooledObject pooledObject;
    [SerializeField] float moveSpeed;
    [SerializeField] float returnTime;
    private float remainTime;
    private void OnEnable()
    {
        remainTime = returnTime;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        remainTime -= Time.deltaTime;            
        if (remainTime < 0)
        {
            pooledObject.ReturnToPool();
        }
    }
}
