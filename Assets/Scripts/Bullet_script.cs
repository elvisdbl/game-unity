using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_script : MonoBehaviour
{   
    public AudioClip Sound;
	public float Speed;
	private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
    	Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);     
    } 

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }
      
    public void Destroybullet(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision){

        Tony_Movement Tony =  collision.collider.GetComponent<Tony_Movement>();
        Grunt_Script Grunt = collision.collider.GetComponent<Grunt_Script>();

        if(Tony != null){
            Tony.Hit();
        }
        if(Grunt != null){
            Grunt.Hit();
        }

        Destroybullet();
    }
}
