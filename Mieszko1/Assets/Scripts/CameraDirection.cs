using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirection : MonoBehaviour {

    public Transform target_mieszko;
    public Vector3 position_camera;
    public Camera main_camera;



	void Start () {

        main_camera = GetComponent<Camera>();
	}
	

	void Update () {

    if (target_mieszko){

            position_camera = new Vector3(0, 0, - 10);
            transform.position = Vector3.LerpUnclamped(transform.position, target_mieszko.position, 0.1f) + position_camera;

        }

		
	}
}
