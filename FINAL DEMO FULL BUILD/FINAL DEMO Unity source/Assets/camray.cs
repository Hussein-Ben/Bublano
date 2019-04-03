using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camray : MonoBehaviour {

    //public Camera camera;
    public GameObject hitting;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        // Ray ray = camera.ScreenPointToRay(transform.forward);

        // if (Physics.Raycast(ray, out hit))
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.transform.gameObject.tag == "hittable")
            {
                hitting = hit.transform.gameObject;
                Transform objectHit = hit.transform;
                //print(objectHit);

                // Do something with the object that was hit by the raycast.
                Material mymat = objectHit.GetComponent<Renderer>().material;

                mymat.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));

                //Check to see if the sound is not playing
                if (!objectHit.GetComponent<AudioSource>().isPlaying)
                {
                    //Play the audio you attach to the AudioSource component
                    objectHit.GetComponent<AudioSource>().Play();

                }
            }
            

        }
    }
}
