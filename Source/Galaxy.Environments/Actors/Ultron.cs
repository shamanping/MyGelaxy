#region using

using System;
using System.Diagnostics;
using System.Windows;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

#endregion

namespace Galaxy.Environments.Actors
{
    public class Ultron : Ship
    {

    #region Constructors

    public Ultron(ILevelInfo info)
        : base(info)
    {
      Width = 30;
      Height = 30;
      ActorType = ActorType.Enemy;
    }

    #endregion

    #region Overrides

    public override void Load()
    {
        base.Load();
        Load(@"Assets\ultron.png");
    }

    #endregion
    public EnemyBullet NewEnemyBullet()
    {
        EnemyBullet bullet = new EnemyBullet(Info);
        int positionY = Position.Y + 30;
        int positionX = Position.X + 15;
        bullet.Position = new Point(positionX, positionY);
        bullet.Load();
        return bullet;
    }

    }
}
