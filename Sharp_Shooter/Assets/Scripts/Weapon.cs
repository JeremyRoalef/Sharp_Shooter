using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    float maxRayDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit interacts with rigidbodys and colliders
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            //If hit has output, this will run
            Debug.Log(hit.collider.name);
        }
    }
}
