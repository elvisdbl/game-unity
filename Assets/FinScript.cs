using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){

    	if(collision.gameObject.tag == "Player"){
    		if(SceneManager.GetActiveScene().name == "SampleScene")  SceneManager.LoadScene(1);
	    	if(SceneManager.GetActiveScene().name == "Nivel_2")  SceneManager.LoadScene(2);
	    	if(SceneManager.GetActiveScene().name == "Nivel_3")  SceneManager.LoadScene(3);

    	}
    }
}
