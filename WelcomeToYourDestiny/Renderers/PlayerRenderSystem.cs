using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Player;

namespace WelcomeToYourDestiny.Renderers
{
    public class PlayerRenderSystem : IRender
    {
        private readonly World _world;

        public PlayerRenderSystem(World world)
        {
            _world = world;
        }

        public void Render(GameTime gameTime)
        {
            //Get PlayerPosition from World;
            if (_world.Has<PlayerPosition>())
            {
                var playerPosition = _world.Get<PlayerPosition>();
                //if changed
                if (playerPosition.Changed)
                {
                    MapLevelDetails map;
                    if (_world.Has<MapLevelDetails>())
                    {
                        map = _world.Get<MapLevelDetails>();
                    }
                    else
                    {
                        map = new MapLevelDetails(10,10);
                        _world.Set(map);
                    }

                    if (playerPosition.OldNumberOfArrayPlayerIsIn!=0)
                    {
                        int index = map.Map[playerPosition.OldNumberOfArrayPlayerIsIn].AreaMapSymbol.IndexOf('X');
                        map.Map[playerPosition.OldNumberOfArrayPlayerIsIn].AreaMapSymbol = map.Map[playerPosition.OldNumberOfArrayPlayerIsIn].AreaMapSymbol.Remove(index, 1);
                        map.Map[playerPosition.OldNumberOfArrayPlayerIsIn].Changed = true;
                    }
                    map.Map[playerPosition.NumberOfArrayPlayerIsIn].AreaMapSymbol += "X";
                    map.Map[playerPosition.NumberOfArrayPlayerIsIn].Changed = true;
                }
            }
        }

    }
}
