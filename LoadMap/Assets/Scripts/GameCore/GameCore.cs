using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

using LoadSystem;

namespace Core
{

	//�������� �����
	//� ��� ���������� �������� ������ �� ����� Resources, ������ �� Json � ��������� �����
	public class GameCore : MonoBehaviour
	{

		private List<Tile> Tiles = new List<Tile>();

		[Header("LoadConfig")]
		[SerializeField] private string loadPath;

		private Camera cam;

		private void Awake()
		{
			//�������� ��������
			LoadSystemMap.Init();
		}

		private void Start()
		{
			cam = GetComponent<Camera>();
			
			//��������� ��� ����� ������ � �� ��������� �� Json � ������ Tiles
			LoadFromFile();
			//������ � Log ���� ���� � ������
			//Print();
			//������������ �����
			Draw();
		}
		private void LoadFromFile()
		{
			//�������� ���������� �� ����
			if(!File.Exists(loadPath))
			{
				Debug.Log("{GameLog} => [GameCore] - LoadFromFile => File not Found");
				return;
			}

			//��������� ���
			string json = File.ReadAllText(loadPath);
			MyJson Info = JsonUtility.FromJson<MyJson>(json);

			Tiles = Info.List;

			//Debug.Log("{GameLog} => [GameCore] - LoadFromFile => Load Done");
		}

		private void Draw()
		{
			//���������� ����� ������ �� Json � ����� �������� �� ����� Resources
			foreach (Tile tile in Tiles)
			{
				foreach(var sprite in LoadSystemMap.Tiles)
				{
					//���� ��� ���������, �� ������������ ������ � ����������� �� ��������� Clone() � ����� �������
					if (tile.Id == sprite.name)
					{
						GameObject obj = (GameObject)Instantiate(sprite, new Vector3(tile.X, tile.Y, 0.0f), Quaternion.identity);
						obj.name = sprite.name;
					}

				}
			}
		}

		private void Print()
		{
			int number = 1;
			foreach(Tile tile in Tiles)
			{
				Debug.Log("Tile Number: " + number);
				Debug.Log("Id: " + tile.Id);
				Debug.Log("Type: " + tile.Type);
				Debug.Log("X: " + tile.X);
				Debug.Log("Y: " + tile.Y);
				Debug.Log("Width: " + tile.Width);
				Debug.Log("Height: " + tile.Height);
				number++;
			}
		}
	}

}
