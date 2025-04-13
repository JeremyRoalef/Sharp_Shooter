using System;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField]
    WeaponSO weaponSO;

    [SerializeField]
    CinemachineVirtualCamera playerFollowCamera;

    [SerializeField]
    GameObject zoomVignette;

    StarterAssetsInputs starterAssetsInputs;

    [SerializeField]
    float maxRayDistance;

    Animator animator;

    Weapon currentWeapon;
    FirstPersonController firstPersonController;
    const string SHOOT_STRING = "Shoot";

    float cameraDefaultZoom;
    float defaultRotationAmount;
    bool canShoot = true;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        cameraDefaultZoom = playerFollowCamera.m_Lens.FieldOfView;
        firstPersonController = GetComponentInParent<FirstPersonController>();
        defaultRotationAmount = firstPersonController.RotationSpeed;
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
            playerFollowCamera.m_Lens.FieldOfView = weaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(weaponSO.ZoomRotateAmount);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = cameraDefaultZoom;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationAmount);
        }
    }
}
