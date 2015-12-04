#region using

using System;
using System.Diagnostics;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

#endregion

namespace Galaxy.Environments.Actors
{
    public class Thunderbolt : BaseActor
    {
        #region Constant

        private const int MaxSpeed = 5;

        #endregion

        #region Private fields

        private bool m_flying;
        private Stopwatch m_flyTimer;
        private bool direction = true;

        #endregion

        #region Constructors

        public Thunderbolt(ILevelInfo info)
            : base(info)
        {
            Width = 30;
            Height = 30;
            ActorType = ActorType.Saboteur;
        }

        #endregion

        #region Overrides

        public override void Update()
        {
            base.Update();

            h_changePosition();
        }

        #endregion

        #region Overrides

        public override void Load()
        {
            Load(@"Assets\thunderbolt.png");
            if (m_flyTimer == null)
            {
                m_flyTimer = new Stopwatch();
                m_flyTimer.Start();
            }
        }

        #endregion

        #region Private methods

        private void h_changePosition()
        {
            Size levelSize = Info.GetLevelSize();

            int yNewPosition = (int)(Position.Y + Math.Round(Math.Sin(Position.X / 20)));

            if (Position.X > (levelSize.Width - 100))
                direction = false;

            if (Position.X < 50)
                direction = true;

            if (direction)
            {
                if (Position.X < 150 || Position.X > levelSize.Width - 200)
                {
                    Position = new Point((int)(Position.X + MaxSpeed), yNewPosition + 3);
                }
                else
                {
                    Position = new Point((int)(Position.X + MaxSpeed), yNewPosition);
                }
            }
            else
            {
                if (Position.X < 150 || Position.X > levelSize.Width - 200)
                {
                    Position = new Point((int)(Position.X - MaxSpeed - 1), yNewPosition + 1);
                }
                else
                {
                    Position = new Point((int)(Position.X - MaxSpeed), yNewPosition);
                }
            }
        }
        #endregion
    }
}
