using Models.Items;
using Models.Map;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class InitializerHelper
    {
        public void WorldInit(Dictionary<Location, Room> roomList, Dictionary<ConnectionLocation, RoomConnection> connectionList)
        {

            Key Room2_6Key = new Key(0, "axe");

            var location1 = new Location(2, 0);
            var location2 = new Location(2, 1);
            var location3 = new Location(1, 0);
            var location4 = new Location(3, 0);
            var location5 = new Location(4, 0);
            var location6 = new Location(2, 2);
            var location7 = new Location(2, 3);
            var location8 = new Location(2, 4);
            var location9 = new Location(3, 4);
            var location10 = new Location(4, 4);
            var location11 = new Location(1, 4);
            var location12 = new Location(0, 4);

            var room1 = new Room("Start", "You have entered the forest. You see a clearing with a large tree ahead of you." + Environment.NewLine + "You see a clearing with a dead end to the left of you." + Environment.NewLine + "You see a long path to the right of you." + Environment.NewLine + "The bridge you entered the forest from is broken behind you.", null);
            var room2 = new Room("StartForward1", "You are in the clearing. A large tree blocks your path ahead of you." + Environment.NewLine + "You see the forest entrance behind you. The trees make the path to your left and right impassable.  ", null);
            var room3 = new Room("StartLeft1", "You are at a dead end. You can only go back to the forest entrance to your right", null);
            var room4 = new Room("StartRight1", "You started moving along the path. You see a large clearing further to the right of you." + Environment.NewLine + "You see the forest entrance to the left of you." + Environment.NewLine + "The trees make the path ahead of you. The cliff makes the path behind you impassable.", null);
            var room5 = new Room("AxeRoom", "You are in the large clearing." + Environment.NewLine + "The forest is dense all around you, making it impassable outside of the path you came from to the left." /*insert fejsze message*/, Room2_6Key);
            var room6 = new Room("AfterTree", "You moved past the large tree. You see a long path ahead of you." + Environment.NewLine + "The trees make the path to your left and right impassable. You see the chopped tree behind you." , null);
            var room7 = new Room("AfterTreeForward1", "You have moved further from the cut down tree. You see a crossroads ahead of you." + Environment.NewLine + "The trees make the path to your left and right impassable. You see the chopped tree further behind you.", null);
            var room8 = new Room("Crossroads", "You have reached the crossroads. You see a path to the left of you." + Environment.NewLine + "You see another path to the right of you. The trees make the path ahead of you impassable.", null);
            var room9 = new Room("CrossroadsRight1", "You started moving along the path." + Environment.NewLine + "You can only move further to the right of you or go back to the crossroads to the left of you.", null);
            var room10 = new Room("CrossroadsRight2", "You reached the end of the forest." + Environment.NewLine + "You see a large field ahead of you with a village further away.", null); //stage end
            var room11 = new Room("CrossroadsLeft1", "You started moving along the path." + Environment.NewLine + "The forest is getting darker as the trees block the sun out more and more as you move further into the forest" + Environment.NewLine + "You can move along the path to the left of you or go back to the crossroads to the right of you.", null);
            var room12 = new Room("CrossroadsLeft2", "You reach the depths of the forest." + Environment.NewLine + "You hear wolf howls further into the forest." + Environment.NewLine + "Your courage fails you and you start thinking about turning back towards the crossroads to the right of you." , null);

            roomList.Add(location1, room1);
            roomList.Add(location2, room2);
            roomList.Add(location3, room3);
            roomList.Add(location4, room4);
            roomList.Add(location5, room5);
            roomList.Add(location6, room6);
            roomList.Add(location7, room7);
            roomList.Add(location8, room8);
            roomList.Add(location9, room9);
            roomList.Add(location10, room10);
            roomList.Add(location11, room11);
            roomList.Add(location12, room12);

            var connectionLocation1_2 = new ConnectionLocation(room1, room2);
            var connectionLocation1_3 = new ConnectionLocation(room1, room3);
            var connectionLocation1_4 = new ConnectionLocation(room1, room4);
            var connectionLocation4_5 = new ConnectionLocation(room4, room5);
            var connectionLocation2_6 = new ConnectionLocation(room2, room6);
            var connectionLocation6_7 = new ConnectionLocation(room6, room7);
            var connectionLocation7_8 = new ConnectionLocation(room7, room8);
            var connectionLocation8_9 = new ConnectionLocation(room8, room9);
            var connectionLocation8_11 = new ConnectionLocation(room8, room11);
            var connectionLocation9_10 = new ConnectionLocation(room9, room10);
            var connectionLocation11_12 = new ConnectionLocation(room11, room12);

            RoomConnection connection1_2 = null;
            RoomConnection connection1_3 = null;
            RoomConnection connection1_4 = null;
            RoomConnection connection4_5 = null;
            RoomConnection connection2_6 = new RoomConnection("Tree", Room2_6Key);
            RoomConnection connection6_7 = null;
            RoomConnection connection7_8 = null;
            RoomConnection connection8_9 = null;
            RoomConnection connection8_11 = null;
            RoomConnection connection9_10 = null;
            RoomConnection connection11_12 = null;

            connectionList.Add(connectionLocation1_2, connection1_2);
            connectionList.Add(connectionLocation1_3, connection1_3);
            connectionList.Add(connectionLocation1_4, connection1_4);
            connectionList.Add(connectionLocation4_5, connection4_5);
            connectionList.Add(connectionLocation2_6, connection2_6);
            connectionList.Add(connectionLocation6_7, connection6_7);
            connectionList.Add(connectionLocation7_8, connection7_8);
            connectionList.Add(connectionLocation8_9, connection8_9);
            connectionList.Add(connectionLocation8_11, connection8_11);
            connectionList.Add(connectionLocation9_10, connection9_10);
            connectionList.Add(connectionLocation11_12, connection11_12);
        }
    }
}
