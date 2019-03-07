using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{	
	//controller
	public float kecepatan;
	// public string axis;
	//conditionss
	public float batasAtas;
	public float batasBawah;

	private GameObject bola;
	private Vector2 bolaPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();	
    }

	void Move(){
		
		if(!bola){
			bola = GameObject.Find("Bola");
		}

		bolaPosition = bola.transform.position;

		if(transform.position.y > batasBawah && bolaPosition.y < transform.position.y){
			transform.localPosition += new Vector3(0,-kecepatan * Time.deltaTime, 0);
		}
		if(transform.position.y < batasAtas && bolaPosition.y > transform.position.y){
			transform.localPosition += new Vector3(0, kecepatan * Time.deltaTime, 0);
		}

		
	}
}
