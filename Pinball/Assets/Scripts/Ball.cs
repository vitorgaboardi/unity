using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public int lives = 3;
    int score = 0;
    bool gameOver = false;
    float height;
    Rigidbody ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
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
            transform.position = new Vector3(5.39f,0.3f,-6.63f);
        }
        else{
            Debug.Log("You still have " + lives + " lives.");
            Debug.Log("Your current score is " + score + " points.");
            transform.position = new Vector3(6.74f,0.3f,-5.68f);
        }
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        var power = Random.Range(0f,1f)*20;

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Obstacle#1")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            score += 100;
            Debug.Log("Nice! You scored 100 points!");
            Debug.Log("You have " + score + " points.");
            
            // Set to random color
            collision.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            ball.AddForce(power*Vector3.forward);
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Obstacle#2")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            score += 200;
            Debug.Log("Great! You scored 200 points!");
            Debug.Log("You have " + score + " points.");
    
            // Set to random color
            collision.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            ball.AddForce(power*Vector3.forward);
        }

                //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Obstacle#3")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Excellent! You scored 300 points!");
            Debug.Log("You have " + score + " points.");
            score += 300;
            
            // Set to random color
            collision.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            ball.AddForce(power*Vector3.forward);
        }
    }
}
