using UnityEngine;
using System.Collections;

using UnityEngine.UI;


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

    //------------
    TextMesh tm;
    string text_buffer;
    float moveSpeed = 10;
    float timing;
    Vector3 target;

    float RotationSpeed = 100f;
    float OrbitSpeed = 50f;
    float DesiredMoonDistance;
   	//-------------
	bool Shaking;
	float ShakeDecay;
	float ShakeIntensity;
	Vector3 OriginalPos;
	Quaternion OriginalRot;

    // Use this for initialization
    void Start () {
		Shaking = true; 
		ShakeDecay = 0.02f;
		ShakeIntensity = 0.3f;    
		OriginalPos = transform.position;
		OriginalRot = transform.rotation;
        difficult = 3f;
        minScale *= transform.localScale.x;
        maxScale *= transform.localScale.y;
        xScale = 0.01f * transform.localScale.x;
        yScale = 0.011f * transform.localScale.y;
        number = Random.Range(1, 7);

        //-----------------------------------
        tm = gameObject.GetComponent<TextMesh>();
        timing = 0;

        DesiredMoonDistance = Vector3.Distance(new Vector3(0,0,10), transform.position);
        //----------------------------------------


    }

	

	// Update is called once per frame
	void Update () {
		Shake ();
//		if (number == 0)
//			Shake ();
////             firstTrans();
//         else if ( number == 1)
//             secondTrans();
//         else if (number == 2)
//             thirdTrans();
//         else  if (number == 3) 
//             myEffect();
//        else
//            myEffect2();

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
   
   //flash effect BALOSAHCE
    void myEffect()
    {
       
        tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, Mathf.PingPong(Time.time * 10,1));
        firstTrans();
        timing += Time.deltaTime;
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
     if (timing > 4)
        {
            ChangeDirection();
            timing = 0;
        }
    }

    void ChangeDirection()
    {
        transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        
    }

   
    void myEffect2 ()
    {
        tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, Mathf.PingPong(Time.time * 10, 1));

        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        transform.RotateAround(new Vector3(0, 0, 20), Vector3.up, OrbitSpeed * Time.deltaTime);

        //fix possible changes in distance
        float currentMoonDistance = Vector3.Distance(new Vector3(0, 0, 20), transform.position);
        Vector3 towardsTarget = transform.position - new Vector3(0, 0, 20);
        transform.position += (DesiredMoonDistance - currentMoonDistance) * towardsTarget.normalized;
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
		

	void Shake () 
	{
		difficult += 0.1f;

		transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
		transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f);

		if(difficult < 50.0f)
			ShakeIntensity += difficult * 0.0001f;
	}
		   
}
