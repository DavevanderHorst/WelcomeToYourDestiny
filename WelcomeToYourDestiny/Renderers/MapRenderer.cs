using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;

namespace WelcomeToYourDestiny.Renderers
{
    public class MapRenderer : IRender
    {
        private readonly World _world;
        public MapRenderer(World world)
        {
            _world = world;
        }
        public void Render(GameTime gameTime)
        {

            if (_world.Has<MapLevelDetails>())
            {
                var map = _world.Get<MapLevelDetails>();
                PrintMap(map.Map);
            }
        }
        public void PrintMap(MapPointDetails[] map)
        {
            var prevPositionTop = Console.CursorTop;
            var prevPositionLeft = Console.CursorLeft;
          
            foreach (var change in map)
            {
                if (change.Changed)
                {
                    change.Changed = false;
                    Console.SetCursorPosition(change.CursorOnMapPoint.Width,change.CursorOnMapPoint.Height);

                    if (change.AreaMapSymbol.Length > 1)
                    {
                        int symbolLenght = change.AreaMapSymbol.Length;
                        Console.Write(change.AreaMapSymbol[symbolLenght-1]);
                    }
                    else
                    {
                        Console.Write(change.AreaMapSymbol);
                    }
                }
            }
            Console.SetCursorPosition(prevPositionTop, prevPositionLeft);
        }
    }
}
