using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;

    [SerializeField]
    float maxRayDistance;

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
        if (starterAssetsInputs.shoot)
        {
            //RaycastHit interacts with rigidbodys and colliders
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                //If hit has output, this will run
                Debug.Log(hit.collider.name);
            }

            starterAssetsInputs.ShootInput(false);
        }
    }
}
