using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using HarryPotterApi.Models;

namespace HarryPotterApi.Services
{
    public class GameLogic
    {
        private static Random rnd = new Random();
        public static StringBuilder sb;
        public static void processTour(Hero myHero,Epee myEpee ,List<Monster> monsterList,List<Gourdin> gourdinList,List<Obstacle> obstacleList, Tuple<int,int> heroLastPosition, Tuple<int,int> attackPosition)
        {

              sb = new StringBuilder();
            /*
             1- Update Hero positions
             2- Process the attack
             3- check if monsters died
             4- Move monsters around
             5- Check if each monster can attack
             6- Check if Hero died
             */
            updateHeroPosition(myHero,heroLastPosition);
            if (attackPosition.Item1 != -1) { 
                processAttackOfHero(myHero, myEpee, monsterList, gourdinList, attackPosition); 
            }
            processMonstersTurn(myHero, monsterList, gourdinList, heroLastPosition, obstacleList);
        }

        private static void updateHeroPosition(Hero myHero, Tuple<int,int> heroLastPosition)
        {
            myHero.SePositionner(heroLastPosition.Item1,heroLastPosition.Item2);
        }

        private static void processAttackOfHero(Hero myHero,Epee myEpee,List<Monster> monsterList,List<Gourdin> gourdinList ,Tuple<int, int> attackPosition)
        {
            
            for(int i = monsterList.Count-1;i>=0;i--)
            {
                double distance = Math.Abs( Math.Sqrt(Math.Pow(attackPosition.Item1, 2) + Math.Pow(attackPosition.Item2, 2)) - Math.Sqrt(Math.Pow(monsterList[i].PositionX, 2) + Math.Pow(monsterList[i].PositionY, 2)));
                if (distance <= myEpee.Portee)
                {
                    sb.AppendFormat("Vous avez infligé {1} points de dégats à {2}.",myHero.Nom,myEpee.Degats,monsterList[i].Nom);
                    sb.AppendLine();
                    if (!monsterList[i].RecevoirDegats(myEpee))
                    {
                        sb.AppendFormat("{0} a succombé.",monsterList[i].Nom);
                        sb.AppendLine();
                        /* When a monster dies we should remove it's weapon from the list*/
                        monsterList.RemoveAt(i);
                        gourdinList.RemoveAt(i);
                        



                    }
                }
                
            }
        }
        /*Returns true if champions is dead*/
        private static bool processMonstersTurn(Hero myHero, List<Monster> monsterList,List<Gourdin> gourdinList ,Tuple<int, int> heroLastPosition,List<Obstacle> obstacleList)
        {
            int x, y;
            for(int i = 0; i < monsterList.Count; i++)
            {
                if (gourdinList[i].Degats != 0)
                {
                    double distance = Math.Abs(Math.Sqrt(Math.Pow(heroLastPosition.Item1, 2) + Math.Pow(heroLastPosition.Item2, 2)) - Math.Sqrt(Math.Pow(monsterList[i].PositionX, 2) + Math.Pow(monsterList[i].PositionY, 2)));
                    if (distance < 3)
                    {
                        sb.AppendFormat("{0} vous a infligé {1} points de dégats.", monsterList[i].Nom, gourdinList[i].Degats);
                        sb.AppendLine();
                        if (!myHero.RecevoirDegats(gourdinList[i]))
                        {
                            sb.AppendFormat("Vous êtes mort!");
                            sb.AppendLine();
                            return true;
                        }
                    }
                }
                do
                {
                    x = monsterList[i].PositionX + rnd.Next(-2, 2);
                    y = monsterList[i].PositionY + rnd.Next(-2, 2);
                } while (positionNotSafe(monsterList[i].Id,x, y, myHero, monsterList, obstacleList));

                monsterList[i].SePositionner(x, y);
            }

            return false;
        }

        private static bool positionNotSafe(int id,int x,int y,Hero myHero,List<Monster> monsterList,List<Obstacle> obstacleList)
        {
            if (x==myHero.PositionX && y == myHero.PositionY)
            {
                return true;
            }
            foreach(Obstacle o in obstacleList)
            {
                if (x == o.PositionX && y == o.PositionY) return true;
            }

            foreach(Monster m in monsterList)
            {
                if (m.Id == id) continue;
                if (x == m.PositionX && y == m.PositionY) return true;
            }

            return false;
        }
    }
}