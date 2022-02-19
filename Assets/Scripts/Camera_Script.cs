using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
   public GameObject Tony;
    void Update()
    {
    	if(Tony != null){
    		        Vector3 position = transform.position;
        position.x = Tony.transform.position.x;

        transform.position =  position;

    	}

    }
}
