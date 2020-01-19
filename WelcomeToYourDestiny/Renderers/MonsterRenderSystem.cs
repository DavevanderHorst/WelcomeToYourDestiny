using System;
using System.Collections.Generic;
using System.Text;
using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Interfaces;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Monsters;

namespace WelcomeToYourDestiny.Renderers
{
    public class MonsterRenderSystem : IRender
    {
        private readonly World _world;

        public MonsterRenderSystem(World world)
        {
            _world = world;
        }

        public void Render(GameTime gameTime)
        {
            if (_world.Has<MonsterMoveController[]>())
            {
                var monsters = _world.Get<MonsterMoveController[]>();
                foreach (var monster in monsters)
                {
                    if (monster.MonsterPosition.Changed)
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

                        if (monster.MonsterPosition.OldNumberOfArrayMonsterIsIn != 0)
                        {
                            int index = map.Map[monster.MonsterPosition.OldNumberOfArrayMonsterIsIn].AreaMapSymbol.IndexOf('M');
                            map.Map[monster.MonsterPosition.OldNumberOfArrayMonsterIsIn].AreaMapSymbol = 
                                map.Map[monster.MonsterPosition.OldNumberOfArrayMonsterIsIn].AreaMapSymbol.Remove(index, 1);
                            map.Map[monster.MonsterPosition.OldNumberOfArrayMonsterIsIn].Changed = true;
                        }
                        map.Map[monster.MonsterPosition.NumberOfArrayMonsterIsIn].AreaMapSymbol += "M";
                        map.Map[monster.MonsterPosition.NumberOfArrayMonsterIsIn].Changed = true;
                    }
                }
            }
        }
    }
}
