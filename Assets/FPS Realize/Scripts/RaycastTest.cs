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
    // 탄창 수
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
        // Physics.Raycast(쏘는 위치, 쏘는 방향, RaycastHit(부딪친 정보 추출), 최대거리(성능상 들어가는게 좋음), 레이어 마스크(타겟 그룹)
        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hit, maxDistance, layerMask))
        {
            // 빨간선을 쏴주는 위치 , 방향, 길이, 색깔
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hit.distance, Color.red);

            text.SetActive(true);

            if (nowammunition > 0)
            {
                //레이저에 부딛친게 있을때 treu
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot(hit);
                }
                // 연사 했을때
                else if (Input.GetMouseButton(0) && !isShooting)
                {
                    StartCoroutine(ContinuousShut(hit));
                }
            }
            else
            {
                Debug.Log("탄창에 탄약이 없습니다.");
                Debug.Log("장전이 필요합니다. (R키)");
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
        Debug.Log($"{hit.collider.gameObject.name}를 맞췄다, hp는 {monHP}남았다.");

        if (monHP == 0)
        {
            Mon.SetActive(false);
            Debug.Log($"{hit.collider.gameObject.name}는 죽었다.");
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
        Debug.Log($"탄창을 장전중입니다.");
        yield return new WaitForSeconds(2f);
        nowammunition = ammunition;
        bulletsText.text = nowammunition + "/" + ammunition;
        Debug.Log($"장전완료");
    }
}
