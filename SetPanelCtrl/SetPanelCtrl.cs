﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;

public class SetPanelCtrl : MonoBehaviour
{
		public UnityEngine.UI.Image JiaoZhunCrossImg;
		public Sprite[] JiaoZhunCross;
		public RectTransform ZhunXingTrP1;
		static SetPanelCtrl _Instance;
		public static SetPanelCtrl GetInstance()
		{
				return _Instance;
		}

		// Use this for initialization
		void Start()
		{
				_Instance = this;
				JiaoZhunCrossImg.enabled = false;
		}

		// Update is called once per frame
		void Update()
		{
				if (Input.GetKeyUp(KeyCode.F4)) {
						InitJiaoZhunZuoBiao();
				}

				if (Input.GetKeyUp(KeyCode.G)) {
//						ChangeJiaoZhunPic();
						if (JiaoZhunCrossImg.enabled)
						{
								CSampleGrabberCB.GetInstance().ActiveJiaoZhunZuoBiao();
						}
				}

				UpdateZhunXingZuoBiao(CSampleGrabberCB.m_curMousePoint);
		}

		void UpdateZhunXingZuoBiao(Point pointVal)
		{
				int px = pointVal.X;
				px = px > 1360 ? 1360 : px;
				px = px < 0 ? 0 : px;

				//int py = 768 - pointVal.Y; //反转坐标Y值信息.
				int py = pointVal.Y;
				py = py > 768 ? 768 : py;
				py = py < 0 ? 0 : py;
				ZhunXingTrP1.localPosition = new Vector3(px, py, 0);
		}

		void InitJiaoZhunZuoBiao()
		{
				if (JiaoZhunCrossImg == null || JiaoZhunCrossImg.enabled) {
						return;
				}
				Debug.Log("InitJiaoZhunZuoBiao!");
//				ZhunXingZB.Visible = false;
//				ZhunXingP1.Visible = false;
				ZhunXingTrP1.gameObject.SetActive(false);
				IndexCrossJZ = 0;
				ChangeJiaoZhunPic();
				JiaoZhunCrossImg.enabled = true;

				if (CSampleGrabberCB.GetInstance() != null) {
						CSampleGrabberCB.GetInstance().InitJiaoZhunZuoBiao();	
				}
//				pcvr.m_CamCB.InitJiaoZhunZuoBiao();
		}

		byte IndexCrossJZ;
		public void ChangeJiaoZhunPic()
		{
				if (!JiaoZhunCrossImg.enabled) {
						return;	
				}

				//Console.WriteLine("indexVal " + indexVal);
				switch (IndexCrossJZ)
				{
				case 0:
				case 1:
				case 2:
				case 3:
						JiaoZhunCrossImg.sprite = JiaoZhunCross[IndexCrossJZ];
						IndexCrossJZ = (byte)(IndexCrossJZ + 1);
						break;
				default:
						IndexCrossJZ = 0;
						JiaoZhunCrossImg.enabled = false;
						ZhunXingTrP1.gameObject.SetActive(true);
//						ZhunXingZB.Visible = true;
//						ZhunXingP1.Visible = true;
						break;
				}
		}
}