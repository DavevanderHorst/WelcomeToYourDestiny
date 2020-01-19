namespace WelcomeToYourDestiny.Models
{
    public class MapPointDetails
    {
        public MapPoint CursorOnMapPoint { get; }
        public string AreaMapSymbol { get; set; }
        public string Description { get; set; }
        public bool Changed { get; set; }
        public int LevelNeededToEnter { get; set; }
        public bool MonsterCanPass { get; set; }

        public MapPointDetails(string areaMapSymbol, string description, MapPoint cursorOnMapPoint, int levelNeededToEnter = 1, bool monsterCanPass = true )
        {
            CursorOnMapPoint = cursorOnMapPoint;
            AreaMapSymbol = areaMapSymbol;
            Description = description;
            LevelNeededToEnter = levelNeededToEnter;
            Changed = true;
            MonsterCanPass = monsterCanPass;
        }
    }
}
