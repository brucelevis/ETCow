﻿using System.Collections.Generic;

namespace ETModel
{
    /// <summary>
    /// 房间管理组件
    /// </summary>
    public class RoomComponent : Component
    {
        private readonly Dictionary<int, Room> rooms = new Dictionary<int, Room>();

        public void Add(Room room)
        {
            this.rooms.Add(room.RoomID, room);
        }
        public Room Get(int id)
        {
            Room room;
            this.rooms.TryGetValue(id, out room);
            return room;
        }
        public Room Remove(int id)
        {
            Room room = Get(id);
            this.rooms.Remove(id);
            return room;
        }
        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();

            foreach (Room room in this.rooms.Values)
            {
                room.Dispose();
            }
            this.rooms.Clear();
        }
    }
}