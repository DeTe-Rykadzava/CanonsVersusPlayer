using System;
using System.Collections;
using System.Collections.Generic;
using CanonScripts;
using Interfaces;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private Transform canonHead;
    [SerializeField] private Transform spawnBulletPoint;
    [SerializeField] private Transform effectPoint;

    [Header("Prefabs")] 
    [SerializeField] private GameObject effectPrefab;
    [SerializeField] private CanonBullet bulletPrefab;

    [Header("Specifications")]
    [SerializeField] private float bulletForce;
    [SerializeField] private float canonRotationToDefaultPosTime = 0.2f;
    
    [Header("Private fields")]
    [SerializeField] private Vector3 _targetPoint = Vector3.zero;
    [SerializeField] private bool _canShoot = true;
    [SerializeField] private float _cooldownShootTime = 0.25f;
    
    private void FixedUpdate()
    {
        if (_targetPoint == Vector3.zero)
            canonHead.rotation = Quaternion.Slerp(canonHead.rotation, Quaternion.identity, canonRotationToDefaultPosTime);
        else
            ChangeRotationHead();
    }

    private void LateUpdate()
    {
        if(_targetPoint == Vector3.zero)
            return;
        if (!_canShoot) return;
            Shoot();
    }

    private void Shoot()
    {
        StartCoroutine(ShowEffect());
        var bullet = Instantiate<CanonBullet>(bulletPrefab, spawnBulletPoint.position, spawnBulletPoint.rotation);
        bullet.AddForce(spawnBulletPoint.forward * bulletForce);
        _canShoot = false;
        StartCoroutine(ShootCooldown());
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(_cooldownShootTime);
        _canShoot = true;
    }

    private IEnumerator ShowEffect()
    {
        var effectObj = Instantiate(effectPrefab, effectPoint);
        yield return new WaitForSeconds(0.6f);
        Destroy(effectObj);
    }

    private void ChangeRotationHead()
    {
        canonHead.LookAt(_targetPoint);
        // var canonRotation = canonHead.rotation.eulerAngles;
        // я не понимаю как ограничить угол *_*
        // canonHead.rotation = Quaternion.Euler(canonRotation);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable obj))
        {
            _targetPoint = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _targetPoint = Vector3.zero;
    }
}
