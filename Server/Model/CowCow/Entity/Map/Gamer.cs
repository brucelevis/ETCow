﻿using System.Collections.Generic;

namespace ETModel
{
    [ObjectSystem]
    public class GamerAwakeSystem : AwakeSystem<Gamer, long>
    {
        public override void Awake(Gamer self, long id)
        {
            self.Awake(id);
        }
    }
    public sealed class Gamer : Entity
    {
        //用户唯一ID        DB数据库的 _id
        public long UserID { get; set; }
        //玩家Gate   ActorID     component 的 InstanceId
        //public long ActorID { get; set; }
        //玩家所在房间号ID
        public string RoomID { get; set; }
        //玩家名
        public string Name { get; set; }
        //玩家所在房间的椅子号
        public int SeatID { get; set; }
        //玩家身份
        public Identity Identity { get; set; }
        //是否准备
        public int Status { get; set; }
        //是否离线
        public bool IsOffline { get; set; }
        //玩家金币
        public int Coin { get; set; }
        //玩家性别
        public int Sex { get; set; }
        //玩家头像
        public string HeadIcon { get; set; }
        //玩家牌
        public List<Card> cards { get; set; }
        //牌类型
        public CardGroupType cardsType { get; set; }
        public void Awake(long id)
        {
            this.UserID = id;
        }
        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();

            this.UserID = 0;
            this.RoomID = string.Empty;
            this.Name = string.Empty;
            this.SeatID = 0;
            this.Identity = Identity.None;
            this.Status = 0;
            this.IsOffline = false;
            this.Coin = 0;
            this.Sex = 0;
            this.HeadIcon = string.Empty;
            this.cards.Clear();
            this.cardsType = CardGroupType.None;
        }
    }
}
