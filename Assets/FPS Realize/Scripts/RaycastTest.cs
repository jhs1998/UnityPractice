using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastTest : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] int MonHP;
    [SerializeField] GameObject Mon;
    [SerializeField] GameObject text;
    [SerializeField] Transform MonTransform;
    private int monHP;
    [SerializeField] float shutdelay;
    // źâ ��
    [SerializeField] int ammunition;
    public TextMeshProUGUI bulletsText;

    private int nowammunition;
   
    private bool spon = false;

    private bool isShooting = false;

    private void Start()
    {
        text.SetActive(false);
        monHP = MonHP;
        nowammunition = ammunition;
        bulletsText.text = nowammunition + "/" + ammunition;
    }
    private void Update()
    {      
        // Physics.Raycast(��� ��ġ, ��� ����, RaycastHit(�ε�ģ ���� ����), �ִ�Ÿ�(���ɻ� ���°� ����), ���̾� ����ũ(Ÿ�� �׷�)
        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hit, maxDistance, layerMask))
        {
            // �������� ���ִ� ��ġ , ����, ����, ����
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hit.distance, Color.red);

            text.SetActive(true);

            if (nowammunition > 0)
            {
                //�������� �ε�ģ�� ������ treu
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot(hit);
                }
                // ���� ������
                else if (Input.GetMouseButton(0) && !isShooting)
                {
                    StartCoroutine(ContinuousShut(hit));
                }
            }
            else
            {
                Debug.Log("źâ�� ź���� �����ϴ�.");
                Debug.Log("������ �ʿ��մϴ�. (RŰ)");
            }
            
        }
        else
        {
            text.SetActive(false);
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red);
        } 

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Rirode());
        }
        
        if (monHP == 0)
        {
            if (!spon)
            {
                spon = true;
                Invoke("Alive", 3f);
            }                     
        }
    }

    private void Shoot(RaycastHit hit)
    {
        monHP -= 1;
        nowammunition -= 1;
        bulletsText.text = nowammunition + "/" + ammunition;
        Debug.Log($"{hit.collider.gameObject.name}�� �����, hp�� {monHP}���Ҵ�.");

        if (monHP == 0)
        {
            Mon.SetActive(false);
            Debug.Log($"{hit.collider.gameObject.name}�� �׾���.");
        }
    }

    private void Alive()
    {         
        Position();
        Mon.SetActive(true);       
        monHP = MonHP;
    }

    private void Position()
    {
        float x;
        float z;
        x = UnityEngine.Random.Range(-20.0f, 20.0f);
        z = UnityEngine.Random.Range(-20.0f, 20.0f);
        MonTransform.position = new Vector3(x, 1.02f, z);
        spon = false;
    }

    private IEnumerator ContinuousShut(RaycastHit hit)
    {
        isShooting = true;

        while (Input.GetMouseButton(0) && nowammunition > 0)
        {
            Shoot(hit);
            yield return new WaitForSeconds(shutdelay);
        }

        isShooting = false;
    }

    private IEnumerator Rirode()
    {
        Debug.Log($"źâ�� �������Դϴ�.");
        yield return new WaitForSeconds(2f);
        nowammunition = ammunition;
        bulletsText.text = nowammunition + "/" + ammunition;
        Debug.Log($"�����Ϸ�");
    }
}
