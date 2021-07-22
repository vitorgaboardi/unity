using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    float power;
    float maxPower = 100f;
    public int score = 0;
    Rigidbody ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ball != null){                           // If the ball triggered the Disparador
            if (Input.GetKey(KeyCode.Space)){       // If the user is pressing the space key
                if (power <= maxPower){             // Ensure the max power
                    power += 60*Time.deltaTime;
                }
                //Debug.Log("power: " + power);
            }
            if (Input.GetKeyUp(KeyCode.Space)){     // If the user stop pressing the space key
                ball.AddForce(power*Vector3.forward);
            }
        }
        else{
            power = 0f;
        }
    }

    // Upon collision with another GameObject, add the component
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")){
            ball = other.gameObject.GetComponent<Rigidbody>();
            //Debug.Log("Bola detectada");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")){
            ball = null;
            power = 0f;
            //Debug.Log("Bola saiu do disparador");
        }
    }
}
