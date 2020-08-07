using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainScreen : MonoBehaviour
{
	public GameObject[] AllScreens,AllButtons,SelectedGamePlayNumbers,Prizes,PickedOutNumbersShow;
	public GameObject SettingButton,ParentButton,LetsPlay,StartTextScreen,MatchedImage,Redeem,HomeButton,RedeemButton,Hand;
	public Animator SettingAnim;
	public Sprite NewSprite,OldSprite;
	int LimitNumber,Rem,Temp;
	public int[] SelectedNumbers,PickedOutNumbers;
	public Text NumRemText,MatchedText;
	int rand,MatchedNumbers;
	bool AlreadyAdded;
    // Start is called before the first frame update
    void Start()
	{
		AlreadyAdded = false;
		Rem = 0;
		Temp = 0;
		LimitNumber = MatchedNumbers = 0;
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

	public void StartButton(){
		StartTextScreen.SetActive(false);
		Hand.SetActive(false);
		InvokeRepeating("PickRandom", 2.0f, 2.0f);
	}

	public void PickRandom(){
		if (Temp <= 7) {
			rand = UnityEngine.Random.Range (1, 20);
			for (int i = 0; i < 8; i++) {
				if (rand == PickedOutNumbers [i]) {
					AlreadyAdded = true;
				} 
			}
			if (!AlreadyAdded) {
				PickedOutNumbers [Temp] = rand;
				PickedOutNumbersShow [Temp].transform.GetChild(0).GetComponent<Text>().text = rand.ToString();
				Temp++;
				MatchCheck ();
			} else {
				AlreadyAdded = false;
				PickRandom ();
			}
		} else if (Temp >= 8) {
			ShowPrize ();
		}
	}

	void ShowPrize(){
		Redeem.SetActive (true);
		MatchedText.text = "You have matched " + MatchedNumbers + " numbers";
		if (MatchedNumbers >= 3) {
			Prizes [MatchedNumbers - 3].SetActive (true);
			RedeemButton.SetActive (true);
		}
		else
			HomeButton.SetActive (true);
	}

	void MatchCheck(){
		for (int i = 0; i < 8; i++) {
			if (rand == SelectedNumbers [i]) {
				MatchedImage.SetActive (true);
				MatchedImage.transform.GetChild(0).GetComponent<Text>().text = rand.ToString();
				Invoke ("HideMatch", 1.0f);
				MatchedNumbers++;
			} 
		}
	}

	void HideMatch(){
		MatchedImage.SetActive (false);
	}

	public void HomeButtonF(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void RedeemButtonF(){
		Application.OpenURL ("https://www.codethislab.com/");
		Invoke ("HomeButtonF", 0.5f);
	}

    // Update is called once per frame
    void Update()
	{
    }
}