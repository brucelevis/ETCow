﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETModel;

namespace ETHotfix
{
    public static class Actor_JoinRoomHelper
    {
        public static async ETVoid OnJoinRoomAsync(long userId, string roomId)
        {
            Session session = Game.Scene.GetComponent<SessionComponent>().Session;
            G2C_CowCowJoinGameRoomGate g2c_Join = (G2C_CowCowJoinGameRoomGate)await session.Call(new C2G_CowCowJoinGameRoomGate() { UserID = userId, RoomID = roomId });

            if (g2c_Join.Error == 0)
            {
                Game.EventSystem.Run(EventIdCowCowType.JoinGameRoom, g2c_Join);
            }
        }
    }
}
