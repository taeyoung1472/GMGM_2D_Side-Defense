using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunManager : MonoBehaviour
{
    
        bool isCanShoot = true, isReload, isShoot;
    int currentBullet;
    public float recoil;
    [SerializeField] private GameObject partPanel, soundObj;
    [SerializeField] private partSystem partSystem;
    [SerializeField] private Transform hand, firePos;
    [SerializeField] private GunInfo currentGun;
    [SerializeField] private Text ammoText, gunNameText;
    [SerializeField] private AudioSource shootAudio, reloadAudio, useAudio;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private SpriteRenderer gunSprite;
    [SerializeField] private float partRecoil = 1, partMagazin = 1;
    GameObject Flash;
 void Start()
    {
        Flash = transform.Find("Flash").gameObject;
        Flash.SetActive(false);
        StartCoroutine(CheckFire());
        SetUp();
    }
    void MuzzleFlash()
    {
        if(isShoot)
        {
            Flash.SetActive(true);
        }
        else 
        {
            Flash.SetActive(false);
        }
    }
    void SetUp()
    {
        currentBullet = currentGun.magazin;
        gunNameText.text = string.Format("{0}", currentGun.gunName);
        ammoText.text = string.Format("{0} / {1}", currentBullet, currentGun.magazin);
        shootAudio.clip = currentGun.shootAudio;
        reloadAudio.clip = currentGun.reloadAudio;
        useAudio.clip = currentGun.useAudio;
        gunSprite.sprite = currentGun.gunSprite;
    }
      private void Update()
    {
        MuzzleFlash();
        CheckInput();
        if (recoil > 0 && !isShoot)
        {
            recoil -= Time.deltaTime * 10;
        }
    }
    IEnumerator CheckFire()
    {
        while (true)
        {
            isShoot = false;
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
        currentBullet = Mathf.RoundToInt(currentGun.magazin * partMagazin);
        ammoText.text = string.Format("{0} / {1}", currentBullet, Mathf.RoundToInt(currentGun.magazin * partMagazin));
        isCanShoot = true;
        isReload = false;
    }

    void Fire()
    {
        if (currentBullet > 0)
        {
                isShoot = true;
                firePos.localEulerAngles = new Vector3(0, 0, Random.Range(-1f,1f) * recoil);
                currentBullet--;
                #region 풀링(총알,사운드)
                if (poolManager.Instance(1).childCount > 0)
                {
                    GameObject obj = poolManager.Get(1).gameObject;
                    obj.SetActive(true);
                    obj.transform.SetParent(poolManager.Holder);
                    obj.transform.position = firePos.position;
                    obj.transform.rotation = firePos.rotation;
                }
                else
            {
                GameObject obj = Instantiate(currentGun.bullet, firePos.position, firePos.rotation);
                obj.transform.SetParent(poolManager.Holder);

            }
            if(poolManager.Instance(0).childCount > 0)
            {
                GameObject obj = poolManager.Get(0).gameObject;
                obj.SetActive(true);
                obj.transform.SetParent(poolManager.Holder);
                obj.GetComponent<SoundObject>().StartAudio(currentGun.shootAudio,shootAudio);
            }
            else
            {
                GameObject obj = Instantiate(soundObj, transform.position, Quaternion.identity);
                obj.GetComponent<SoundObject>().StartAudio(currentGun.shootAudio,shootAudio);
            }
            #endregion
            ammoText.text = string.Format("{0} / {1}", currentBullet, Mathf.RoundToInt(currentGun.magazin * partMagazin));
            if(currentGun.fireMode == GunInfo.FireMode.semi)
            {
                cameraManager.Shake(currentGun.recoil * partRecoil * 0.1f, currentGun.shootDelay * 0.25f);
            }
            else
            {
                cameraManager.Shake(currentGun.recoil * partRecoil * 0.1f, currentGun.shootDelay);
            }
            recoil += currentGun.recoil * partRecoil;
        }
    }
    public void ChangeWeapone(GunInfo newGun)
    {
        currentGun = newGun;
        SetUp();
        useAudio.Play();
    }
    public void OpenPartPanel()
    {
        partPanel.SetActive(true);
    }
    public void SetPart()
    {
        partRecoil = 1; partMagazin = 1;
        for (int i = 0; i < currentGun.isCanPart.Length; i++)
        {
            if (currentGun.isCanPart[i])
            {
                partRecoil -= partSystem.GetPartInfo(i).recoilFix;
                partMagazin += partSystem.GetPartInfo(i).magazinFix;
            }
        }
    }
    public void ClosePartPanel()
    {
        partPanel.SetActive(false);
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReload)
        {
            StartCoroutine(Reload());
        }
    }
}