using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// failed at gaze base on rotation - keep this as a refrence
public class gaze_move : MonoBehaviour {
    Transform waypoint_pos, y_pos;
    GameObject main_cam;
    Transform main_cam_rotation, main_cam_transform;
    float waypoint_current_xpos, waypoint_current_zpos;
    float user_gaze;
    float reset_waypoint_xpos, reset_waypoint_ypos, reset_waypoint_zpos;
    float user_zpos, user_xpos;
    float decreaser = 0.5f;

    // Use this for initialization
    void Start () {
        waypoint_pos = GetComponent<Transform>();
        main_cam = GameObject.Find("FPSController");

        main_cam_rotation = main_cam.GetComponent<Transform>();
        main_cam_transform = main_cam.GetComponent<Transform>();

        reset_waypoint_xpos = waypoint_pos.position.x;
        reset_waypoint_ypos = waypoint_pos.position.y;
        reset_waypoint_zpos = waypoint_pos.position.z;

    }

    // Update is called once per frame
    void Update () {
        user_gaze = main_cam_rotation.rotation.y;
        user_zpos = main_cam_transform.position.z;
        user_xpos = main_cam_transform.position.x;
        print("user_gaze:" + user_gaze);

        waypoint_current_xpos = waypoint_pos.position.x;
        waypoint_current_zpos = waypoint_pos.position.z;


        // if user looks right 90
        if (user_gaze <= 0.99 && user_gaze >= 0.95)
        {
            waypoint_pos.position = new Vector3(reset_waypoint_xpos -= decreaser, reset_waypoint_ypos, reset_waypoint_zpos);

            if (waypoint_current_xpos <= 16)
            {
                decreaser = 0;
            }

        } else if (user_gaze <= 0.86 && user_gaze >= 0.25) // looks right 180
        {
            decreaser = 0.5f;
            waypoint_pos.position = new Vector3(reset_waypoint_xpos, reset_waypoint_ypos, reset_waypoint_zpos += decreaser);

            if (waypoint_current_zpos <= 34)
            {
                decreaser = 0;
            }
        } else if (user_gaze >= 0.25 && user_gaze <= 0.40)
        {
            decreaser = 0.5f;
            waypoint_pos.position = new Vector3(reset_waypoint_xpos += decreaser, reset_waypoint_ypos, reset_waypoint_zpos);

            if (waypoint_current_xpos >= 24)
            {
                decreaser = 0;
            }
        }
        else if (user_gaze >= 0.40 && user_gaze <= 0.95) // back to start
        {
            decreaser = 0.5f;
            waypoint_pos.position = new Vector3(reset_waypoint_xpos, reset_waypoint_ypos, reset_waypoint_zpos -= decreaser);

            if (waypoint_current_zpos >= 24)
            {
                decreaser = 0;
            }
        }


            print("waypoint position: " + waypoint_pos.position);


    }
}
