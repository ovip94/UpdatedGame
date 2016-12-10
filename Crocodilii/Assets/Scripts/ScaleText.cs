using UnityEngine;
using System.Collections;

public class ScaleText : MonoBehaviour {
    public float difficult;

    float minScale = 0.5f;
    float maxScale = 1.5f;

    int xDir = 1;
    int yDir = 1;
    int zDir = 1;
    int number;

    float xScale;
    float yScale;


    // Use this for initialization
    void Start () {
        difficult = 3f;
        minScale *= transform.localScale.x;
        maxScale *= transform.localScale.y;
        xScale = 0.01f * transform.localScale.x;
        yScale = 0.011f * transform.localScale.y;
        number = Random.Range(1,254);

    }

	
	// Update is called once per frame
	void Update () {
     
        if ( number % 3 == 0)
            firstTrans();
        else if ( number % 3 == 1)
            secondTrans();
        else
        thirdTrans();
    }


    // micsorare si marire
    void firstTrans()
    {
        if (transform.localScale.x > maxScale) {
            xDir = -1;
        }
        if (transform.localScale.x < minScale) {
            xDir = 1;
        }

        if (transform.localScale.y > maxScale) {
            yDir = -1;
        }
        if (transform.localScale.y < minScale) {
            yDir = 1;
        }

        if (transform.localScale.z > maxScale) {
            zDir = -1;
        }
        if (transform.localScale.z < minScale) {
            zDir = 1;
        }

        if (xDir == 1) {
            transform.localScale += new Vector3(xScale * difficult, 0, 0);
        } else {
            transform.localScale -= new Vector3(xScale * difficult, 0, 0);
        }

        if (yDir == 1) {
            transform.localScale += new Vector3(0, yScale * difficult, 0);
        }
        else {
            transform.localScale -= new Vector3(0, yScale * difficult, 0);

        }
    }

    // mers rapid catre stanga
    void secondTrans()
    {
        float dist = 20.0f;
        if (transform.position.x + dist < 0.01 && transform.position.x < 0) {
            transform.Translate(Vector3.right * dist * 2, Camera.main.transform);
        }

        transform.Translate(Vector3.left , Camera.main.transform);
    }

    // rotire in jurul lui OY
    void thirdTrans()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 700, Space.World);
    }
}
