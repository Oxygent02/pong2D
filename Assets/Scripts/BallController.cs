using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{	
	//bola
	public int force;
	int initSpeed;
	Rigidbody2D rigid;
	Vector2 arah;

	//score
	int scoreP1;
	int scoreP2;

	//textScore
	Text scoreUIP1;
	Text scoreUIP2;

	//endscreen
	GameObject panelSelesai;
    Text txPemenang; 

	//ball sound effect
	AudioSource audio;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {	
		//init audio
		audio = GetComponent<AudioSource>();

		//init score
		scoreP1 = 0;
		scoreP2 = 0;
		panelSelesai = GameObject.Find ("PanelSelesai");
		panelSelesai.SetActive(false);

		//random arah bola awal
		for (int i = 0; i < 1000; i++)
         {
			while(initSpeed == 0){
				initSpeed = Random.Range(-5, 5);
			}
         }

        rigid = GetComponent<Rigidbody2D>();
		MoveBola(initSpeed,0);

		//tampilkan score di layar
		scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
		scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
    }

	//efek benturan
	private void OnCollisionEnter2D(Collision2D coll){
		//colision sound effect
		audio.PlayOneShot(hitSound);

		if (coll.gameObject.name == "TepiKanan"){
			ResetBall();
			MoveBola(2,0);
			scoreP1 +=1;
			showScore();

			if (scoreP1 == 5) {
                panelSelesai.SetActive (true);
                txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
                txPemenang.text = "The Winner is: Blue Player!";
                Destroy (gameObject);
                return;
            }
		}
		if (coll.gameObject.name == "TepiKiri"){
			ResetBall();
			MoveBola(-2,0);
			scoreP2 +=1;
			showScore();

			if (scoreP2 == 5) {
                panelSelesai.SetActive (true);
                txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
                txPemenang.text = "The Winner is: Red Player!";
                Destroy (gameObject);
                return;
            } 
		}
		if(coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2"){
			float sudut = (transform.position.y - coll.transform.position.y)*5f;
			MoveBola((int)rigid.velocity.x, sudut);
		}
	}
	
	//gerakan bola
	void MoveBola(int velocityX, float directionAfterCollided){
		arah = new Vector2(velocityX,directionAfterCollided).normalized;
		int bonusSpeed = 2;

		if(directionAfterCollided != 0){
			rigid.velocity = new Vector2(0,0);
			bonusSpeed = 5;
		}
		
		rigid.AddForce(arah * force * bonusSpeed);
	}

	//reset bola
	void ResetBall(){
		transform.localPosition = new Vector2 (0,0);
		rigid.velocity = new Vector2(0,0);
	}

	//tampilkan score
	void showScore(){
		scoreUIP1.text = scoreP1 + "";
		scoreUIP2.text = scoreP2 + "";
	}

}
