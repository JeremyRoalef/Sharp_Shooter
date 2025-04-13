using System;
using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField]
    WeaponSO weaponSO;

    StarterAssetsInputs starterAssetsInputs;

    [SerializeField]
    float maxRayDistance;

    Animator animator;

    Weapon currentWeapon;
    const string SHOOT_STRING = "Shoot";

    bool canShoot = true;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    private void HandleShoot()
    {
        //Conditions to stop
        if (!starterAssetsInputs.shoot) { return; }
        if (!canShoot) { return; }

        canShoot = false;
        Invoke("EnableShooting", weaponSO.FireRate);

        currentWeapon.Shoot(weaponSO);
        //Play the shoot animation, passing the layer and normalized time (0 for each)
        animator.Play(SHOOT_STRING, 0, 0f);

        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    void EnableShooting()
    {
        canShoot = true;
    }

    public void SwitchWeapon(WeaponSO newWeaponSO)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }

        //Change weapon
        weaponSO = newWeaponSO;
        Weapon newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
    }

    void HandleZoom()
    {
        if (!weaponSO.CanZoom) { return; }

        if (starterAssetsInputs.zoom)
        {
            Debug.Log("Zooming in");
        }
        else
        {
            Debug.Log("Not zooming in");
        }
    }
}
