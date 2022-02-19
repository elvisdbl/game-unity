using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tony_Movement : MonoBehaviour
{
	public GameObject BulletPrefab;
    public float Speed;
    public float JumpForce;
	private Rigidbody2D Rigidbody2D;
    private Animator Animator;
	private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    private int Health = 5;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal"); 
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        else if (Horizontal > 0.0f) transform.localScale  = new Vector3(1.0f,1.0f,1.0f);

        Animator.SetBool("Running",Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;

        }else{
            Grounded = false;
        }  
        
        if(Input.GetKeyDown(KeyCode.W) && Grounded)
        {
        	Jump();
        }

        if(Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f){
        	Shoot();
        	LastShoot = Time.time;
        }

        if(transform.position.y <= -0.9f){
        	Destroy(gameObject);	
        	Reload();
        }
    }

    	private void Shoot(){
    		Vector3 direction;
    		if(transform.localScale.x == 1.0f) direction = Vector3.right;
    		else direction = Vector3.left;

    		GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
    		bullet.GetComponent<Bullet_script>().SetDirection(direction);
    	}
    	
	    private void Jump(){
	    	Rigidbody2D.AddForce(Vector2.up * JumpForce); 
	    }

	    private void FixedUpdate(){
	    	Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
	    }

	    public void Hit(){
	    	Health = Health - 1;
	    	if(Health == 0){

	    		Destroy(gameObject);	
	    		Reload();

	    	}
	    }

	    public void Reload(){
	    	if(SceneManager.GetActiveScene().name == "SampleScene")  SceneManager.LoadScene(0);
	    	if(SceneManager.GetActiveScene().name == "Nivel_2")  SceneManager.LoadScene(1);
	    	if(SceneManager.GetActiveScene().name == "Nivel_3")  SceneManager.LoadScene(2);
	    }

}