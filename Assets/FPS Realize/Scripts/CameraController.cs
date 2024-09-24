using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera3;

    [SerializeField] GameObject aim;

    private void Start()
    {
        camera1.SetActive(false);
        camera3.SetActive(true);
        aim.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            CameraChange();
        }
        else
        {
            camera1.SetActive(false);
            camera3.SetActive(true);
        }

    }

    private void CameraChange()
    {
        camera1.SetActive(true);
        camera3.SetActive(false);
        aim.SetActive(true);
    }
}
