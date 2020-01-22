using WelcomeToYourDestiny.GameCoreComponents;
using WelcomeToYourDestiny.Models;
using WelcomeToYourDestiny.Monsters;

namespace WelcomeToYourDestiny.MapCreators
{
    public class LevelOne
    {
        public MapPointDetails[] CreateMap(int width, int height)
        {
            int mapWidth = width * 2;
            int index = 0; 

            var map = new MapPointDetails[width*height];
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < mapWidth; j+=2)
                {
                    if (i == 0 || j == 0 || index > ((height -1)*width)-1|| (index+1)%(width)==0) //making the edges impenetrable.
                    {
                        map[index] = (new MapPointDetails("#", "Impenetrable terrain!",
                            new MapPoint(j , i )));
                    }
                    else if(index == 108)
                    {
                        map[index] = (new MapPointDetails(".", "A strange sandy dry desert...", 
                            new MapPoint(j, i),2, false));
                    }
                    else if(index == 216)
                    {
                        map[index] = (new MapPointDetails(".", "A strange sandy dry desert...", 
                            new MapPoint(j, i),3, false));
                    }
                    else if((j == mapWidth / 3) || (j == mapWidth/3*2))
                    {
                        map[index] = (new MapPointDetails("#", "Impenetrable terrain!",
                            new MapPoint(j , i )));
                    }
                    else
                    {
                        map[index] = (new MapPointDetails(".", "A strange sandy dry desert...", 
                            new MapPoint(j, i)));
                    }

                    index++;
                }
            }

            return map;
        }

        public MonsterMoveController[] CreateMonsters(World world, MapLevelDetails map)
        {
            MonsterPosition monster1 = new MonsterPosition(map, world);
            MonsterStats statsMonster1 = new MonsterStats("rabbit");
            monster1.MoveTo(151, statsMonster1);
            MonsterPosition monster2 = new MonsterPosition(map, world);
            MonsterStats statsMonster2 = new MonsterStats("rabbit");
            monster2.MoveTo(152, statsMonster2);
            MonsterPosition monster3 = new MonsterPosition(map, world);
            MonsterStats statsMonster3 = new MonsterStats("rabbit");
            monster3.MoveTo(177, statsMonster3);
            MonsterPosition monster4 = new MonsterPosition(map, world);
            MonsterStats statsMonster4 = new MonsterStats("cat");
            monster4.MoveTo(60, statsMonster4);
            MonsterPosition monster5 = new MonsterPosition(map, world);
            MonsterStats statsMonster5 = new MonsterStats("cat");
            monster5.MoveTo(36, statsMonster5);
            MonsterPosition monster6 = new MonsterPosition(map, world);
            MonsterStats statsMonster6 = new MonsterStats("cat");
            monster6.MoveTo(37, statsMonster6);
            MonsterMoveController[] monsters = new MonsterMoveController[6];
            monsters[0] = new MonsterMoveController(monster1, statsMonster1);
            monsters[1] = new MonsterMoveController(monster2,statsMonster2);
            monsters[2] = new MonsterMoveController(monster3,statsMonster3);
            monsters[3] = new MonsterMoveController(monster4, statsMonster4);
            monsters[4] = new MonsterMoveController(monster5,statsMonster5);
            monsters[5] = new MonsterMoveController(monster6,statsMonster6);
            return monsters;
        }
    }
}
