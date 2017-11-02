using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordUI : MonoBehaviour {

	public RectTransform panel;
	public Image[] btn;
	public RectTransform center;
	public Image samImg;
	public Image hatImg;
	public bool debug;
	
	float[] distanceToCenter;
	bool dragging = false;
	int btnDistance;
	int minButtonNum;
	GameObject scrollPanel;
	int lastButton;
	
	void Start(){
		int btnLength = btn.Length;
		distanceToCenter = new float[btnLength];
		btnDistance = (int)Mathf.Abs(btn[1].GetComponent<RectTransform>().anchoredPosition.x - btn[0].GetComponent<RectTransform>().anchoredPosition.x);
		scrollPanel = GameObject.Find("scrollPanel");
	}
	
	void Update(){
		for(int i = 0; i < btn.Length; i++){
			distanceToCenter[i] = Mathf.Abs(center.transform.position.x - btn[i].transform.position.x);
		}
		
		float minDistance = Mathf.Min(distanceToCenter);
		
		for (int a = 0; a < btn.Length; a++){
			if (minDistance == distanceToCenter[a]){
				int lastMinButtonNum = minButtonNum;
				minButtonNum = a;
				if(minButtonNum != lastMinButtonNum){
					if(btn[a].sprite.name.Contains("+")){
						samImg.transform.localScale = new Vector3(1f,1f,1f);
						hatImg.transform.localScale = new Vector3(0f,0f,0f);
					}
					if(btn[a].sprite.name.Contains("-")){
						hatImg.transform.localScale = new Vector3(1f,1f,1f);
						samImg.transform.localScale = new Vector3(0f,0f,0f);
					}
					if(btn[a].sprite.name.Contains("transparent")){
						//Vector2 newPanelPos = new Vector2(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x+700,scrollPanel.GetComponent<RectTransform>().anchoredPosition.y);
						//scrollPanel.GetComponent<RectTransform>().anchoredPosition = newPanelPos;
						minButtonNum = lastButton;
					}
				}
			}
		}
		
		if (!dragging){
			LerpToBtn(minButtonNum * -btnDistance);
		}
		
		/*if(scrollPanel){
			if(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x < -1882){
				Vector2 newPanelPos = new Vector2(400,scrollPanel.GetComponent<RectTransform>().anchoredPosition.y);
				scrollPanel.GetComponent<RectTransform>().anchoredPosition = newPanelPos;
			} 
			if(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x > 402){
				Vector2 newPanelPos = new Vector2(-1182,scrollPanel.GetComponent<RectTransform>().anchoredPosition.y);
				scrollPanel.GetComponent<RectTransform>().anchoredPosition = newPanelPos;
			}
			
		}*/
	}
	
	void LerpToBtn(int position){
		float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 5f);
		Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);
		
		panel.anchoredPosition = newPosition;
	}
	
	public void moveLeft(){
			GameObject scrollPanel = GameObject.Find("scrollPanel");
			Vector2 newPanelPos;
			if(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x >= -10){
				print(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x);
				newPanelPos = new Vector2(-1400f,scrollPanel.GetComponent<RectTransform>().anchoredPosition.y);
			}else newPanelPos = new Vector2(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x+700,scrollPanel.GetComponent<RectTransform>().anchoredPosition.y);

			scrollPanel.GetComponent<RectTransform>().anchoredPosition = newPanelPos;
			print(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x);
	}
	
	public void moveRight(){
			GameObject scrollPanel = GameObject.Find("scrollPanel");
			Vector2 newPanelPos;
			
			if(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x <= -1300){
				print(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x);
				newPanelPos = new Vector2(0f,scrollPanel.GetComponent<RectTransform>().anchoredPosition.y);
			}else newPanelPos = new Vector2(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x-700,scrollPanel.GetComponent<RectTransform>().anchoredPosition.y);

			scrollPanel.GetComponent<RectTransform>().anchoredPosition = newPanelPos;
			print(scrollPanel.GetComponent<RectTransform>().anchoredPosition.x);
	}
	public void StartDrag(){
		dragging = true;
	}
	
	public void EndDrag(){
		dragging = false;
	}
	
	public void loadNextWords(string target){
		
		Vector2 newPanelPos = new Vector2(400,scrollPanel.GetComponent<RectTransform>().anchoredPosition.y);
		scrollPanel.GetComponent<RectTransform>().anchoredPosition = newPanelPos;
		minButtonNum = 0;
		
		lastButton = -1;
		List<Sprite> textImages = loadImages(target);
		Sprite transparent = Resources.Load<Sprite>("dialogue/_transparent");


		int buttonNum =0;
		for(int i = 0; i < btn.Length; i++){
			print(textImages[i]);
			if(i < textImages.Count){
				btn[buttonNum].sprite = textImages[i];
				lastButton++;
			}
			else{
				btn[buttonNum].sprite = transparent;
			}
			buttonNum++;
		}
		
		if(btn[0].sprite.name.Contains("+")){
			samImg.transform.localScale = new Vector3(1f,1f,1f);
			hatImg.transform.localScale = new Vector3(0f,0f,0f);
		}
		if(btn[0].sprite.name.Contains("-")){
			hatImg.transform.localScale = new Vector3(1f,1f,1f);
			samImg.transform.localScale = new Vector3(0f,0f,0f);
		}
	}
	
	List<Sprite> loadImages(string target){
		Sprite[] imagesGO = Resources.LoadAll<Sprite>("");
		List<Sprite> selectedImgs = new List<Sprite>();;
		foreach(Sprite img in imagesGO){
			if (img.name.Contains(target)){
				selectedImgs.Add(img);
			}
		}
		return selectedImgs;
	}
	
	public void dPrint(string text){
		if(debug){
			print(text);
		}
	}
}