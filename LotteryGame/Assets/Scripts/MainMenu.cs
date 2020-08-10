using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
	public GameObject[] AllScreens;
	public MainScreen MS;
    // Start is called before the first frame update
    void Start()
    {
		MainFunction ();
    }

	public void OpenPayTable(){
		AllScreens [3].SetActive (true);
	}

	public void ClosePayTable(){
		AllScreens [3].SetActive (false);
	}

	public void MainFunction(){
		for (int i = 0; i < AllScreens.Length; i++) {
			if (i == 0)
				AllScreens [i].SetActive (true);
			else
				AllScreens [i].SetActive (false);
		}
	}

	public void Picknumbers(){
		if (AllScreens [2].activeSelf) {
			AllScreens [3].SetActive (false);
		}
		else{
			for (int i = 0; i < AllScreens.Length; i++) {
				if (i == 1)
					AllScreens [i].SetActive (true);
				else
					AllScreens [i].SetActive (false);
			}
		}
	}

	public void Gameplay(){
		Array.Sort(MS.SelectedNumbers);
		for (int i = 0; i < AllScreens.Length; i++) {
			if (i == 2)
				AllScreens [i].SetActive (true);
			else
				AllScreens [i].SetActive (false);
		}
		MS.GamePlayNumbers ();
	}

	public void Paytable(){
		for (int i = 0; i < AllScreens.Length; i++) {
			if (i == 3)
				AllScreens [i].SetActive (true);
			else
				AllScreens [i].SetActive (false);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}