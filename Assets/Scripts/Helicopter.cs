using UnityEngine;
using System.Collections;
using System;

public class Helicopter : MonoBehaviour {

    public float thrustForce;
    public float dragForce;
    public float liftForce;
    public float weightForce;
    public float tailForceRight;
    public float tailForceLeft;
    public float strafeRight;
    public float strafeLeft;
    public float bladeSpeed;
    public float resultantHorizontal;
    public float resultantVertical;
    public float resultantTail;
    public float resultantStrafe;

    public string playerName;
    public Transform blades;
    private Transform helicopter;

    // Aceleration
    public float acelerationFactor = .08F;

    // Deaceleration
    public float deacelerationFactor = .02F;


    // Use this for initialization
    void Start () {
        this.helicopter = this.transform;

        this.thrustForce = 0;
        this.liftForce = 0;
        this.weightForce = 0;
        this.tailForceRight = 0;
        this.tailForceLeft = 0;

        this.playerName = "Chuck Norris";
	}
	
	// Update is called once per frame
	void Update () {
        bindControls();
        moveHelicopter();
    }

    private void bindControls()
    {

        Boolean pressForward = (Input.GetKey("w"));
        Boolean pressBackward = (Input.GetKey("s"));
        Boolean pressUp = (Input.GetKey("up"));
        Boolean pressDown = (Input.GetKey("down"));
        Boolean pressTurnRight = (Input.GetKey("d"));
        Boolean pressTurnLeft = (Input.GetKey("a"));
        Boolean pressStrafeRight = (Input.GetKey("q"));
        Boolean pressStrafeLeft = (Input.GetKey("e"));

        this.thrustForce = positiveAceleration(this.thrustForce, pressForward);
        this.liftForce = positiveAceleration(this.liftForce, pressUp);
        this.tailForceRight = positiveAceleration(this.tailForceRight, pressTurnRight);
        this.strafeRight = positiveAceleration(this.strafeRight, pressStrafeRight);
        this.dragForce = negativeAceleration(this.dragForce, pressBackward);
        this.weightForce = negativeAceleration(this.weightForce, pressDown);
        this.tailForceLeft = negativeAceleration(this.tailForceLeft, pressTurnLeft);
        this.strafeLeft = negativeAceleration(this.strafeLeft, pressStrafeLeft);

        
    }

    private float positiveAceleration(float force, Boolean isInteration)
    {
        // aceleration
        force += isInteration ? acelerationFactor : 0;

        //deaceleration
        if (!isInteration && force > 0) { force -= deacelerationFactor; }
        else if (!isInteration && force < 0) { force = 0; }

        return force;
    }

    private float negativeAceleration(float force, Boolean isInteration)
    {
        // aceleration
        force -= isInteration ? acelerationFactor : 0;

        //deaceleration
        if (!isInteration && force < 0) { force += deacelerationFactor; }
        else if (!isInteration && force > 0) { force = 0; }

        return force;
    }

    private void moveHelicopter()
    {

        bladeSpeed = 10;
        resultantHorizontal = (thrustForce + dragForce);
        resultantVertical = (liftForce + weightForce);
        resultantTail = tailForceRight + tailForceLeft;
        resultantStrafe = strafeRight + strafeLeft;

        if (resultantHorizontal > 0)
        {
            bladeSpeed = resultantHorizontal + resultantHorizontal * bladeSpeed;
        }
        else if (resultantVertical < 0)
        {
            bladeSpeed = 6;

        }

        blades.Rotate(0, bladeSpeed, 0);
        helicopter.Translate(resultantHorizontal, resultantVertical, resultantStrafe);
        helicopter.Rotate(0, resultantTail, 0);
    }

    
}
