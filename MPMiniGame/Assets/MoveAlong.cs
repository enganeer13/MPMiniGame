using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    Rigidbody2D rb;
    SliderJoint2D slider;
    JointMotor2D motorRef;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider = GetComponent<SliderJoint2D>();
        motorRef = slider.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.jointTranslation <= slider.limits.min)
        {
            motorRef.motorSpeed = Mathf.Abs(motorRef.motorSpeed);
            slider.motor = motorRef;
        }
        else if (slider.jointTranslation >= slider.limits.max)
        {
            motorRef.motorSpeed = Mathf.Abs(motorRef.motorSpeed) * -1;
            slider.motor = motorRef;
        }
    }
}
