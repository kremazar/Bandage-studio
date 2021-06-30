using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderRegion : MonoBehaviour
{
    [Tooltip("Size of the box")]
    public Vector3 size;


    public Vector3 GetRandomPointWithin(){
        float x = transform.position.x + Random.Range(size.x * - 0.5f, size.x * 0.5f);
        float z = transform.position.z + Random.Range(size.x * - 0.5f, size.x * 0.5f);
        return new Vector3(x, transform.position.y, z);
    }

    void Awake() {
        //Get all of our Wanderer children:
        var wanderers = gameObject.GetComponentsInChildren<Wanderer>();

        //Loop through the children:
        for(int i = 0; i < wanderers.Length; i++){
            Debug.Log("Imas toliko wanderera" + i);
            //Set their .region reference to 'this' script instance:
            wanderers[i].region = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
