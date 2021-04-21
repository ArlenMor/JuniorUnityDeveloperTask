using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    //����������� �����, ������� ���������� ��������� ���� �������� ������ �� ����� Resources
    public static class LoadSystemMap
    {

        //���� � ����� � ��������� � ����� Resources
        private const string Path = "Sprites/BGPrefabs";
        
        static private Object[] s_Tiles;

        public static Object[] Tiles => s_Tiles;

        static public void Init()
        {
            s_Tiles = Resources.LoadAll(Path);
        }

    }
}
