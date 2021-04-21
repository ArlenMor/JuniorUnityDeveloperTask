using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;

namespace UI
{
    //����� ��� ������ � UI
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefabPanel;
        [SerializeField]
        private Camera cam;
        
        //������� ������ � �����������
        public void CreatePanel()
        {
            GameSettings.canMoveCamera = false;
            Instantiate(prefabPanel, new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z), Quaternion.identity);
        }
    }

}
