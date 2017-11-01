using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables

    public GameObject Line;

    public Vector2 TouchPos = new Vector2();

    public Vector2 CalculatedPosition = new Vector2();

    public float LaunchMagnatitude;

    public float LaunchAngle;

    private bool Launchable;

    public float LineOffset;
    #endregion

    private void Start()
    {
        Line.gameObject.SetActive(false);
    }

    private void Update()
    {
        //Makes sure there is a touch and makes sure the object is stuck to the bottom.
        if (Input.touchCount > 0 && this.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            //Gets touch phase and selects which position its in.
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                TouchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.nearClipPlane));
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                /*Sets the ending of the Sprite to be in the middle of the lauching one*/
                Line.transform.position = new Vector3(this.transform.position.x, LineOffset, this.transform.position.z);
                Line.gameObject.SetActive(true);

                CalculatedPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.nearClipPlane));

                LaunchAngle = EqualOppAngle(AngleBetweenVector2(this.transform.position, CalculatedPosition));
                LaunchAngle = AngleCheck(LaunchAngle);

                Line.transform.eulerAngles = new Vector3(0, 0, LaunchAngle);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Line.gameObject.SetActive(false);
                Launch(LaunchAngle);
            }
        }
    }

    //Finds the angles between the 2 vectors of your gameobject and your touch.
    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

    //Converts - angle received from launch to a positive one.
    float EqualOppAngle(float Angle)
    {
        return Angle += 180;
    }

    //Forces Angles to be in bounds. Doesn't allow it to be launched if it's not in the correct bounds.
    float AngleCheck(float Angle)
    {
        
        if (Angle > 170 && Angle < 270)
        {
            Line.gameObject.SetActive(false);
            Angle = 10;
            Launchable = false;
        }
        else if (Angle > 270 && Angle < 360)
        {
            Line.gameObject.SetActive(false);
            Angle = 170;
            Launchable = false;
        }
        else
        {
            Line.gameObject.SetActive(true);
            Launchable = true;
        }
        return Angle;
    }

    //Lauches the object in a straight line at the angle necessary.
    public void Launch(float Angle)
    {
        if (Launchable)
        {
            Vector3 dir = Quaternion.AngleAxis(Angle, Vector3.forward) * Vector3.right;
            GetComponent<Rigidbody2D>().AddForce(dir * LaunchMagnatitude);
        }
    }

}
