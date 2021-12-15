using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunManager : MonoBehaviour
{
    bool isCanShoot = true, isReload;
    int currentBullet;
    [SerializeField] private Transform hand, firePos;
    [SerializeField] private GunInfo currentGun;
    [SerializeField] private Text ammoText, gunNameText;
    [SerializeField] private AudioSource shootAudio, reloadAudio, useAudio;
    private void Start()
    {
        StartCoroutine(CheckFire());
        SetUp();
    }
    void SetUp()
    {
        currentBullet = currentGun.magazin;
        gunNameText.text = string.Format("{0}", currentGun.gunName);
        ammoText.text = string.Format("{0} / {1}", currentBullet, currentGun.magazin);
        shootAudio.clip = currentGun.shootAudio;
        reloadAudio.clip = currentGun.reloadAudio;
        useAudio.clip = currentGun.useAudio;
    }
    private void Update()
    {
        CheckInput();
    }
    IEnumerator CheckFire()
    {
        while (true)
        {
            yield return new WaitUntil(() => isCanShoot);
            switch (currentGun.fireMode)
            {
                case GunInfo.FireMode.semi:
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
                    Fire();
                    yield return new WaitForSeconds(currentGun.shootDelay);
                    break;
                case GunInfo.FireMode.burst:
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
                    for (int i = 0; i < 3; i++)
                    {
                        Fire();
                        yield return new WaitForSeconds(currentGun.shootDelay * 0.33f);
                    }
                    yield return new WaitForSeconds(currentGun.shootDelay);
                    break;
                case GunInfo.FireMode.auto:
                    yield return new WaitUntil(() => Input.GetKey(KeyCode.Mouse0));
                    Fire();
                    yield return new WaitForSeconds(currentGun.shootDelay);
                    break;
            }
        }
    }
    IEnumerator Reload()
    {
        reloadAudio.Play();
        isReload = true;
        isCanShoot = false;
        yield return new WaitForSeconds(currentGun.reloadTime);
        currentBullet = currentGun.magazin;
        ammoText.text = string.Format("{0} / {1}", currentBullet, currentGun.magazin);
        isCanShoot = true;
        isReload = false;
    }
    void Fire()
    {
        if (currentBullet > 0)
        {
            Instantiate(currentGun.bullet, firePos.position, hand.rotation);
            currentBullet--;
            shootAudio.Play();
            ammoText.text = string.Format("{0} / {1}", currentBullet, currentGun.magazin);
        }
    }
    public void ChangeWeapone(GunInfo newGun)
    {
        currentGun = newGun;
        SetUp();
        useAudio.Play();
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReload)
        {
            StartCoroutine(Reload());
        }
    }
}