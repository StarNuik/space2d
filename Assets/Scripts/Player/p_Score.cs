using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p_Score : MonoBehaviour
{
    public int score;
	public Text scoreText;

	void drawScore() {
		scoreText.text = score.ToString("0000000");
	}

	public void addScore(int ammount) {
		score += ammount;
		if (score > 9999999) {
			Debug.Log("You won1");
		}
		drawScore();
	}
}
