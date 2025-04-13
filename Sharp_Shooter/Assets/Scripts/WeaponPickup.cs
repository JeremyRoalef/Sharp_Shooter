using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField]
    WeaponSO weaponSO;

    const string PLAYER_STRING = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            //Debug.Log(other.gameObject.name);
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();

            if (activeWeapon != null)
            {
                activeWeapon.SwitchWeapon(weaponSO);
            }

            Destroy(gameObject);
        }
    }
}
