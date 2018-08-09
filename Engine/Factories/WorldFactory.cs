using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "FarmFields.png");

            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbor, Farmer Joe.",
                "Farmhouse.png");

            newWorld.LocationAt(-1, -1).TraderHere = TraderFactory.GetTraderByName("Farmer Ted");

            newWorld.AddLocation(0, -1, "Home",
                "This is your home.",
                "Home.png");

            newWorld.AddLocation(0, 0, "Town Square", 
                "You see a fountain.",
                "TownSquare.png");

            newWorld.AddLocation(-1, 0, "Trading Shop", 
                "Susan's shop.", 
                "Trader.png");

            newWorld.LocationAt(-1, 0).TraderHere = TraderFactory.GetTraderByName("Susan");

            newWorld.AddLocation(1, 0, "Town Gate", 
                "This is the town gate", 
                "TownGate.png");

            newWorld.AddLocation(2, 0, "SpiderForest", 
                "This is where spiders dwell.", 
                "SpiderForest.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Herbalist's Hut", 
                "This is where the herbalist lives.", 
                "HerbalistsHut.png");

            newWorld.LocationAt(0, 1).TraderHere = TraderFactory.GetTraderByName("Pete the Herbalist");

            // Add quest at Herbalist Hut
            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 2, "Herb Garden", 
                "This is where the herbs are.", 
                "HerbalistsGarden.png");

            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}
