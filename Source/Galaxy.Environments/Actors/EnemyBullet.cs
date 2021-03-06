﻿#region using

using System.Drawing;
using Galaxy.Core.Actors;

#endregion

namespace Galaxy.Core.Environment
{
    public class EnemyBullet : BaseActor
    {
        #region Constant

        private const int Speed = 10;

        #endregion

        #region Constructors

        public EnemyBullet(ILevelInfo info)
            : base(info)
        {
            Width = 5;
            Height = 8;
            ActorType = ActorType.Enemy;
        }

        #endregion

        #region Overrides

        public override void Load()
        {
            Load(@"Assets\bullet.png");
        }

        public override void Update()
        {
            Position = new Point(Position.X, Position.Y + Speed);
        }

        #endregion
    }
}