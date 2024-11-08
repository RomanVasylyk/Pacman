using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject objectToFollow;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void LateUpdate() {
         transform.position =
            objectToFollow.transform.position
            + new Vector3(0,0,-10);
     }

}
