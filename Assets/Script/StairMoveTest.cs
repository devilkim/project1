using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairMoveTest : MonoBehaviour {

    public float _speed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,_speed * Time.deltaTime * -1,0);

        if ( transform.localPosition.y < -16.0f)
        {
            transform.localPosition = new Vector3(0,0.0f,0);
      
        }
    
	}
}
