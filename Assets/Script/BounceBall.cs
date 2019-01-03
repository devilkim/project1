using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour {

    public float BounceTopY = 100;

    private float basedY = -1;
    private bool isUp = true;
    private float totalDeltaTime = 0;

    // Use this for initialization
    void Start () {
        Debug.Log("Sin");
        Debug.Log(Mathf.Sin(Mathf.Deg2Rad * 0));
        Debug.Log(Mathf.Sin(Mathf.Deg2Rad * 45));
        Debug.Log(Mathf.Sin(Mathf.Deg2Rad * 90));
    }

// Update is called once per frame
    void Update () {
        transform.Translate(0, DeltaY(transform.position.y), 0);
    }

    private float DeltaY(float currentY) {
        if (isUp) {
            totalDeltaTime += Time.deltaTime;
        } else {
            totalDeltaTime -= Time.deltaTime;
        }

        if (basedY < 0) {
            basedY = currentY;
        }

        if (totalDeltaTime >= 1f) {
            totalDeltaTime = 1f;
            isUp = false;
        } 

        if (totalDeltaTime <= 0f) {
            totalDeltaTime = 0f;
            isUp = true;
        }

        if (isUp) {
            return (CurveY() * (basedY + BounceTopY)) - currentY;
        } else {
            return (CurveY() * (basedY + BounceTopY)) - currentY;
        }
    }

    private float CurveY()
    {
        //return ((Mathf.Cos(Mathf.Deg2Rad * 90 * totalDeltaTime) * -1) + 1) / 2;
        return Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * 90 * totalDeltaTime));
    }




    /*
    private float CurveY() {
        return ((Mathf.Cos(Mathf.Deg2Rad * 90 * Time.deltaTime) * -1) + 1) / 2;
    }

    private float DeltaY() {

        return movementPixelPerSecond * CurveY() * (isUp ? 1 : -1);

    }
*/
}
