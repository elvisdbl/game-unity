using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Script : MonoBehaviour
{

	public GameObject BulletPrefab;
   public GameObject Tony;
   private float LastShoot;
   private int Health = 3;

   private void Update(){
   	   if(Tony == null) return;

   	Vector3 direction  = Tony.transform.position - transform.position;

   	if(direction.x >= 0.0f) transform.localScale = new Vector3(1.0f , 1.0f, 1.0f);
   	else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

   	float distance = Mathf.Abs(Tony.transform.position.x - transform.position.x);

   	if(distance < 1.0f && Time.time > LastShoot + 0.30f){
   		Shoot();
   		LastShoot = Time.time;
   	}

   	if(transform.position.y <= -0.9f){
        	Destroy(gameObject);	
    }

   }

   private void Shoot(){
   		Vector3 direction;
    	if(transform.localScale.x == 1.0f) direction = Vector3.right;
    	else direction = Vector3.left;

    	GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
    	bullet.GetComponent<Bullet_script>().SetDirection(direction);	 
   }

   	public void Hit(){
	    	Health = Health - 1;
	    	if(Health == 0){
	    		Destroy(gameObject);
	    	}
	    }
}
