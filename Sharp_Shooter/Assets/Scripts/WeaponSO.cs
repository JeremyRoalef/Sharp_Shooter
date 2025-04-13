using StarterAssets;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponSO", fileName = "ScriptableObjects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [Tooltip("The amount of damage one shot will do")]
    public int Damage = 1;
    [Tooltip("The size of each magazine")]
    public int MagazineSize = 6;
    [Tooltip("The time it takes to reload the weapon")]
    public float ReloadTime = 1f;
    [Tooltip("The delay (in seconds) between each shot fired")]
    public float FireRate = 0.5f;



    [SerializeField]
    float maxRayDistance;

    [SerializeField]
    ParticleSystem muzzleFlash;

    [SerializeField]
    Animator animator;

    [SerializeField]
    GameObject hitVFXPrefab;
}
