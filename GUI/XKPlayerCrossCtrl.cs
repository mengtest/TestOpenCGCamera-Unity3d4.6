﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class XKPlayerCrossCtrl : MonoBehaviour
{
		[Range(0, 3)]public byte PlayerIndex;
		static XKPlayerCrossCtrl _InstanceP1;
		static XKPlayerCrossCtrl _InstanceP2;
		static XKPlayerCrossCtrl _InstanceP3;
		static XKPlayerCrossCtrl _InstanceP4;
		public static XKPlayerCrossCtrl GetInstance(byte indexPlayer)
		{
				XKPlayerCrossCtrl playerCross = null;
				switch (indexPlayer) {
				case 0:
						playerCross = _InstanceP1;
						break;
				case 1:
						playerCross = _InstanceP2;
						break;
				case 2:
						playerCross = _InstanceP3;
						break;
				case 3:
						playerCross = _InstanceP4;
						break;
				}
				return playerCross;
		}

		Transform CrossTr;
		RectTransform CrossRtTr;
		// Use this for initialization
		void Awake()
		{
				switch (PlayerIndex) {
				case 0:
						_InstanceP1 = this;
						break;
				case 1:
						_InstanceP2 = this;
						break;
				case 2:
						_InstanceP3 = this;
						break;
				case 3:
						_InstanceP4 = this;
						break;
				}

				CrossRtTr = GetComponent<RectTransform>();
				if (CrossRtTr == null) {
						CrossTr = transform;
				}
		}

		void FixedUpdate()
		{
				UpdatePlayerCrossPos();
		}

		Vector3 CrossPos;
		public void UpdateZhunXingZuoBiao(Point pointVal)
		{
				int px = pointVal.X;
				px = px > 1360 ? 1360 : px;
				px = px < 0 ? 0 : px;

				//int py = 768 - pointVal.Y; //反转坐标Y值信息.
				int py = pointVal.Y;
				py = py > 768 ? 768 : py;
				py = py < 0 ? 0 : py;
				CrossPos = new Vector3(px, py, 0);
		}

		void UpdatePlayerCrossPos()
		{
				if (CrossTr != null) {
						CrossTr.localPosition = CrossPos;
				}

				if (CrossRtTr != null) {
						CrossRtTr.localPosition = CrossPos;
				}
		}

		public static void SetAllCrossActive(bool isActive)
		{
				_InstanceP1.SetCrossActive(isActive);
				_InstanceP2.SetCrossActive(isActive);
				_InstanceP3.SetCrossActive(isActive);
				_InstanceP4.SetCrossActive(isActive);
		}

		void SetCrossActive(bool isActive)
		{
				gameObject.SetActive(isActive);
		}
}