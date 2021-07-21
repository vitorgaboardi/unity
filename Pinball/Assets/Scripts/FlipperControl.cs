using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    public float initPosition = 0f;
    public float finalPosition = 90f;
    public float hitStrength = 1000f;
    public float flipperDamper = 150f;
    public string inputName;
    HingeJoint hingeJoint;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Create variable and define parameters
        JointSpring springJoint = new JointSpring();
        springJoint.damper = flipperDamper;
        springJoint.spring = hitStrength;
        
        // Check if it is pressed
        if (Input.GetAxis(inputName) == 1){
            springJoint.targetPosition = finalPosition;
        } 
        else{
            springJoint.targetPosition = initPosition;
        }

        hingeJoint.spring = springJoint;
        hingeJoint.useLimits = true;
        
    }
}
