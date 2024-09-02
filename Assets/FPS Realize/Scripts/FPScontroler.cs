using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroler : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;

    [SerializeField] Transform camTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Look();
        Move();
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime);
    }

    private void Look()
    {
        float x = Input.GetAxis("Mouse X"); //���콺 �¿� ������
        float y = Input.GetAxis("Mouse Y"); //���콺 ���Ʒ� ������

        transform.Rotate(Vector3.up, rotateSpeed * x * Time.deltaTime);
        camTransform.Rotate(Vector3.right, rotateSpeed * -y * Time.deltaTime);

    }
}
