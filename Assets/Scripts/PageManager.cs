using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
	 public bool isEscapeToExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (isEscapeToExit) {
				Application.Quit ();
			} else {
			KembaliKeMenu ();
			}
		}
    }

	public void vsAI ()
    {
    SceneManager.LoadScene ("MainAI");
    }
	public void vsP2 ()
    {
    SceneManager.LoadScene ("MainP2");
    }
    public void KembaliKeMenu ()
    {
    SceneManager.LoadScene ("Menu");
    }
	public void keluar() {
    Application.Quit();
	}
}
