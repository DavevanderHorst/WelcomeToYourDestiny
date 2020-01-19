using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.MapCreators;

namespace WelcomeToYourDestiny.Models
{
    public class MapLevelDetails
    {
        public MapPointDetails[] Map { get; set; }
        public int MapHeight { get; set; }
        public int MapWidth { get; set; }

        public MapLevelDetails(int mapWidth, int mapHeight)
        {
            LevelOne levelOne = new LevelOne();
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            Map = levelOne.CreateMap(MapWidth, MapHeight);
        }
    }
}
