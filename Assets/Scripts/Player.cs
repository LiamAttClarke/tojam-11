﻿using UnityEngine;
using System.Collections;

public enum PlayerType { Front, Back }

public class Player : MonoBehaviour {

	struct InputBinding {
		public string LL;
		public string LU;
		public string RL;
		public string RU;
		public InputBinding (string LL, string LU, string RL, string RU) {
			this.LL = LL;
			this.LU = LU;
			this.RL = RL;
			this.RU = RU;
		}
	}

	public PlayerType playerType = PlayerType.Front;

	Leg leftLeg, rightLeg;

	InputBinding inputBindings;
	
	GameManager gameManager;

	void Awake () {
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		leftLeg = transform.Find ("Left Leg").GetComponent<Leg>();
		rightLeg = transform.Find ("Right Leg").GetComponent<Leg>();

		switch (playerType) {
		case PlayerType.Front:
			inputBindings = new InputBinding ("Front_LL", "Front_LU", "Front_RL", "Front_RU");
			break;
		case PlayerType.Back:
			inputBindings = new InputBinding ("Back_LL", "Back_LU", "Back_RL", "Back_RU");
			break;
		}
	}
	
	void Update () {
		if (!gameManager.isGameOver) {
			leftLeg.MoveToPosition ( LegType.Lower, (Input.GetAxis (inputBindings.LL) + 1f) * 0.5f);
			leftLeg.MoveToPosition ( LegType.Upper, Input.GetButton (inputBindings.LU) ? 1f : 0);
			rightLeg.MoveToPosition ( LegType.Lower, (Input.GetAxis (inputBindings.RL) + 1f) * 0.5f);
			rightLeg.MoveToPosition ( LegType.Upper, Input.GetButton (inputBindings.RU) ? 1f : 0);		
		}
	}
}
