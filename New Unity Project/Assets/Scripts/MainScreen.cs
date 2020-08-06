using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainScreen : MonoBehaviour
{
	public GameObject[] AllScreens,AllButtons,SelectedGamePlayNumbers;
	public GameObject SettingButton,ParentButton,LetsPlay;
	public Animator SettingAnim;
	public Sprite NewSprite,OldSprite;
	int LimitNumber,Rem;
	public int[] SelectedNumbers;
	public Text NumRemText;
    // Start is called before the first frame update
    void Start()
	{
		Rem = 0;
		LimitNumber = 0;
		MainMenu ();
		SettingAnim = SettingButton.GetComponent<Animator>();
    }

	public void EightButtons(int Num){
		if (AllButtons [Num - 1].GetComponent<Image> ().sprite == NewSprite) {
			AllButtons[Num-1].GetComponent<Image> ().sprite = OldSprite;
			for (int i = 0; i < 8; i++) {
				if(SelectedNumbers [i] == Num){
					SelectedNumbers [i] = 0;
				}
			}
			LimitNumber--;
//			Array.Sort(SelectedNumbers);
		}
		else if (LimitNumber < 8) {
			for (int i = 0; i < 8; i++) {
				if (SelectedNumbers [i] == 0) {
					AllButtons[Num-1].GetComponent<Image> ().sprite = NewSprite;
					SelectedNumbers [i] = Num;
					LimitNumber++;
					break;
				}
			}
		}
		if ((8 - LimitNumber) != 0) {
			NumRemText.text = "PICK " + (8 - LimitNumber) + " NUMBERS";
			LetsPlay.GetComponent<Button> ().interactable = false;
		}
		else {
			NumRemText.text = "Let's Play";
			LetsPlay.GetComponent<Button> ().interactable = true;
		}

	}

	public void MainMenu(){
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
		Array.Sort(SelectedNumbers);
		for (int i = 0; i < AllScreens.Length; i++) {
			if (i == 2)
				AllScreens [i].SetActive (true);
			else
				AllScreens [i].SetActive (false);
		}
		GamePlayNumbers ();
	}

	public void Paytable(){
		for (int i = 0; i < AllScreens.Length; i++) {
			if (i == 3)
				AllScreens [i].SetActive (true);
			else
				AllScreens [i].SetActive (false);
		}
	}

	public void Setting(){
		if (SettingAnim.GetBool ("SettingOption") == false)
			SettingAnim.SetBool ("SettingOption", true);	
		else
			SettingAnim.SetBool ("SettingOption", false);
	}

	public void OpenPayTable(){
		AllScreens [3].SetActive (true);
	}

	public void ClosePayTable(){
		AllScreens [3].SetActive (false);
	}

	public void GamePlayNumbers(){
		for (int i = 0; i < 8; i++) {
			SelectedGamePlayNumbers [i].transform.GetChild(0).GetComponent<Text>().text = SelectedNumbers[i].ToString();
		}
	}

    // Update is called once per frame
    void Update()
    {
		
    }
}