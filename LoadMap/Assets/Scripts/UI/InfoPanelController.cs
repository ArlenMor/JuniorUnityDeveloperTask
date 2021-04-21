using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace UI
{

    //����� ��� ������ � ������������ �����
    public class InfoPanelController : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        private void Start()
        {
            LeftTopTileInfo(); 
        }
        public void ClosePanel()
        {
            Destroy(this.gameObject);
            GameSettings.canMoveCamera = true;
        }

        //������ � ��������� ���� ��� �����, ������� ������� � ����� ������� ���� ������
        private void LeftTopTileInfo()
        {
            Camera cam = FindObjectOfType<Camera>();
            //������� ����� ������� ����
            Vector3 point = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane));

            //������� ������ ������ ������� ����
            GameObject[] obj = GameObject.FindGameObjectsWithTag("BG");

            //���������, ���� ����� ������ � ������� �����, �� ������� ��� ���
            foreach(GameObject tile in obj)
            {
                
                //need to fix
                float LeftBorder = tile.transform.position.x - 2.56f;
                float RightBorder = tile.transform.position.x + 2.56f;
                float UpBorder = tile.transform.position.y + 2.56f;
                float DownBorder = tile.transform.position.y - 2.56f;

                if (point.x > LeftBorder && point.x < RightBorder && point.y > DownBorder && point.y < UpBorder)
                {
                    text.text = tile.name;
                }
                    
            }

        }
    }

}
