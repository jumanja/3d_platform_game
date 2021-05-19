using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;
    
    private bool isGrounded;
    public int score;
    public UI ui;

    // Update is called once per frame
    void Update()
    {
        //get horizontal and vertical inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //setting our velocity based on our inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        //face forward using a copy of velocity
        Vector3 vel = rig.velocity;
        vel.y = 0;

        //only when we are moving, if we are not moving on, don't rotate
        if(vel.x != 0 || vel.z != 0){
           transform.forward = vel;
        }

        //detect space bar to jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //GameOver (10 mts  or units off the platform)
        if(transform.position.y < -10){
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision){
        //we are colliding with an object facing up
        if(collision.contacts[0].normal == Vector3.up){
            isGrounded = true;
        }
    }

    public void GameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount) {
        score += amount;
        ui.SetScoreText(score);
    }
}
