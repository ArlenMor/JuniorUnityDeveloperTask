using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSystem
{
    [System.Serializable] 

    //структура отдельного тайла
    public struct Tile
    {
        public string Id;
        public string Type;
        public float X;
        public float Y;
        public float Width;
        public float Height;
    }

    //структура всего джейсона
    public struct MyJson
    {
        public List<Tile> List;
    }

}
