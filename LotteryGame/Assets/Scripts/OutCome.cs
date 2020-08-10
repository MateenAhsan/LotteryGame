using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class OutCome : MonoBehaviour
{
	public GameObject MatchedImage;
	public int[] PickedOutNumbers;

	public MainScreen MSC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void MatchCheck(){
		print ("From Out Come Matched");
		for (int i = 0; i < 8; i++) {
			if (MSC.rand == MSC.SelectedNumbers [i]) {
				MatchedImage.SetActive (true);
				MatchedImage.transform.GetChild(0).GetComponent<Text>().text = MSC.rand.ToString();
				Invoke ("HideMatch", 1.0f);
				MSC.MatchedNumbers++;
			} 
		}
	}

	void HideMatch(){
		MatchedImage.SetActive (false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
