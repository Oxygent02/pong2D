using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
	//controller
	public float kecepatan;
	public string axis;
	//conditionss
	public float batasAtas;
	public float batasBawah;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//controller
		float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
		
		//condition
		float nextPos = transform.position.y + gerak;
		if (nextPos >= batasAtas){
			gerak = 0;
		}
		if (nextPos <= batasBawah){
			gerak = 0;
		}

		//set Transform
		transform.Translate(0, gerak, 0);
    }
}
