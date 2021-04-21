using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoadSystem
{
    //Статический класс, который занимается выгрузкой всех префабов тайлов из папки Resources
    public static class LoadSystemMap
    {

        //путь к папке с префабами в папке Resources
        private const string Path = "Sprites/BGPrefabs";
        
        static private Object[] s_Tiles;

        public static Object[] Tiles => s_Tiles;

        static public void Init()
        {
            s_Tiles = Resources.LoadAll(Path);
        }

    }
}
