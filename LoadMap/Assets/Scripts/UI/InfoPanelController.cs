using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace UI
{

    // ласс дл€ работы с всплывающиим окном
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

        //¬ыводи в текстовое поле им€ тайла, который находит в левом верхнем углу экрана
        private void LeftTopTileInfo()
        {
            Camera cam = FindObjectOfType<Camera>();
            //находим левый верхний угол
            Vector3 point = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane));

            //создаем массив нашего заднего фона
            GameObject[] obj = GameObject.FindGameObjectsWithTag("BG");

            //провер€ем, если точка входит в пределы тайла, то выводим его им€
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
