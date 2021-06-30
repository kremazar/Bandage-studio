using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WanderRegion))]
public class WanderRegionInspector : Editor
{ 
    private const float BoxHeight = 2f;
    private WanderRegion Target{
        get{
            return (WanderRegion)target;
        }
    }

    void OnSceneGUI() {
       //Make the handles white:
        Handles.color = Color.red; 
        //Draw a wireframe cube resembling the wander region:
        Handles.DrawWireCube(Target.transform.position + (Vector3.up * 
        BoxHeight * .5f),new Vector3(Target.size.x,BoxHeight,Target.size.z));
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
