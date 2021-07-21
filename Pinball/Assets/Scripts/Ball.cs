using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public int lives = 3;
    bool gameOver = false;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(6.74f,0.5f,-5.68f);
    }

    // Update is called once per frame
    void Update()
    {
        float height = transform.position.y;
        if(height < -1.5f && gameOver == false){
            lostLive();
        }
        
    }

    private void lostLive()
    {
        lives -= 1;
        if (lives == 0){
            Debug.Log("Your score was " + score + " points.");
            Debug.Log("Game Over");
            gameOver = true;
            transform.position = new Vector3(5.39f,0.5f,-6.63f);
        }
        else{
            Debug.Log("You still have " + lives + " lives.");
            transform.position = new Vector3(6.74f,0.5f,-5.68f);
        }
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Obstacle#1")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            score += 100;
            //Debug.Log("Obstacle#1");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Obstacle#2")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            score += 200;
            //Debug.Log("Obstacle#2");
        }

                //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Obstacle#3")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            score += 300;
            //Debug.Log("Obstacle#3");
        }
    }
}
