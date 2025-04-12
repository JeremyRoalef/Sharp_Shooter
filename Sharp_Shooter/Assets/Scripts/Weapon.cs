using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;

    [SerializeField]
    float maxRayDistance;

    [SerializeField]
    int damageAmount = 1;

    //RaycastHit interacts with rigidbodys and colliders
    RaycastHit hit;


    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        //Conditions to stop
        if (!starterAssetsInputs.shoot) { return; }


        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            //If hit has output, this will run
            Debug.Log(hit.collider.name);

            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount); //Enemy health null? (same as below)

            /*
            if (hit.transform.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                Debug.Log("Hit enemy");
                enemyHealth.TakeDamage(damageAmount);
            }
            */
        }

        starterAssetsInputs.ShootInput(false);
    }
}
