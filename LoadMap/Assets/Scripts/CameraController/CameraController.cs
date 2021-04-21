using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Core;

namespace CameraController
{
    //класс для работы с камерой
    public class CameraController : MonoBehaviour
    {
        private Vector2 startPos;
        private Camera cam;

        private void Start()
        {
            cam = GetComponent<Camera>();
            //задаем начальную позицию для камеры
            cam.transform.position = new Vector3(15, -7, -10);
        }

        private void Update()
        {
            //проверяем на возможность передвижение камеры
            if (!GameSettings.canMoveCamera) return;
            //если нажали на кнопку мыши, запоминаем ее координаты
            if(Input.GetMouseButtonDown(0))
            {
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
            }
            //если удерживаем, то меняем позицию мыши
            else if (Input.GetMouseButton(0))
            {
                float posX = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
                float posY = cam.ScreenToWorldPoint(Input.mousePosition).y - startPos.y;

                //fix it                                                                    lb      rb
                //границы можно задать с помощью вычисления длины и ширины всей карты
                //и записи этой информации в статический класс GameSettings
                //но пока что пойдёт и костыль с примерным расположением
                transform.position = new Vector3(Mathf.Clamp(transform.position.x - posX, 6.36f, 29.46f), Mathf.Clamp(transform.position.y - posY, -7.7f, -2.46f), transform.position.z);
            }
        }
    }
}
