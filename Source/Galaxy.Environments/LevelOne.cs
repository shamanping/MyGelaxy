//<<<<<<< HEAD
﻿#region using

using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Galaxy.Core.Actors;
using Galaxy.Core.Collision;
using Galaxy.Core.Environment;
using Galaxy.Environments.Actors;

#endregion

namespace Galaxy.Environments
{
  /// <summary>
  ///   The level class for Open Mario.  This will be the first level that the player interacts with.
  /// </summary>
  public class LevelOne : BaseLevel
  {
    private int m_frameCount;

    #region Constructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="LevelOne" /> class.
    /// </summary>
    public LevelOne()
    {
        //stopwatch
        m_stopwatch = new Stopwatch();
        m_stopwatch.Start();
      // Backgrounds
      FileName = @"Assets\LevelOne.png";

      // Enemies
      for (int i = 0; i < 5; i++)
      {
        var ship = new Ship(this);
        int positionY = ship.Height + 50;
        int positionX = 150 + i * (ship.Width + 50);

        ship.Position = new Point(positionX, positionY);

        ship.Check = i%2 == 0;

        Actors.Add(ship);
      }

//=======
//>>>>>>> parent of f10ca14... Revert "Создание нового класса врагов "Ultron" и добавление его на уровень"
     
      //Ultron
        var ultron = new Ultron(this);
        int ultronpositionY = ultron.Height + 90;
        int ultronpositionX = ultron.Width + 270;
        ultron.Position = new Point(ultronpositionX, ultronpositionY);
        Actors.Add(ultron);

      //Saboteur
      var thunderbolt = new Thunderbolt(this);
      int saboteurpositionY = Size.Height + 20;
      int saboteurpositionX = Size.Width;
      thunderbolt.Position = new Point(saboteurpositionX, saboteurpositionY);
      Actors.Add(thunderbolt);

//<<<<<<< HEAD

      // Player
      Player = new PlayerShip(this);
      int playerPositionX = Size.Width / 2 - Player.Width / 2;
      int playerPositionY = Size.Height - Player.Height - 50;
      Player.Position = new Point(playerPositionX, playerPositionY);
      Actors.Add(Player);
    }

    #endregion

    #region Overrides

    private void h_dispatchKey()
    {
      if (!IsPressed(VirtualKeyStates.Space)) return;

      if(m_frameCount % 10 != 0) return;

      Bullet bullet = new Bullet(this)
      {
        Position = Player.Position
      };

      bullet.Load();
      Actors.Add(bullet);
    }

    private void AddActor()
    {
        Ultron[] ultron = Actors.Where(actor => actor is Ultron).Cast<Ultron>().ToArray();
        if (m_stopwatch.ElapsedMilliseconds > 300)
        {
            foreach (var ship in ultron)
            {
                Actors.Add(ship.NewEnemyBullet());
                m_stopwatch.Restart();
            }

        }
        EnemyBullet[] bullets = Actors.Where(actor => actor is EnemyBullet).Cast<EnemyBullet>().ToArray();
        foreach (var s in bullets)
        {
            if (s.Position.Y >= BaseLevel.DefaultHeight)
            {
                Actors.Remove(s);
            }
        }
    }

    public override BaseLevel NextLevel()
    {
      return new StartScreen();
    }

    private Stopwatch m_stopwatch;

    public override void Update()
    {
      m_frameCount++;
      h_dispatchKey();
      AddActor();

      base.Update();

      IEnumerable<BaseActor> killedActors = CollisionChecher.GetAllCollisions(Actors);

      foreach (BaseActor killedActor in killedActors)
      {
        if (killedActor.IsAlive)
          killedActor.IsAlive = false;
      }

      List<BaseActor> toRemove = Actors.Where(actor => actor.CanDrop).ToList();
      BaseActor[] actors = new BaseActor[toRemove.Count()];
      toRemove.CopyTo(actors);

      foreach (BaseActor actor in actors.Where(actor => actor.CanDrop))
      {
        Actors.Remove(actor);
      }

      if (Player.CanDrop)
        Failed = true;

      //has no enemy
      if (Actors.All(actor => actor.ActorType != ActorType.Enemy))
        Success = true;
    }

    #endregion

      
  }
}
//=======
//>>>>>>> parent of f10ca14... Revert "Создание нового класса врагов "Ultron" и добавление его на уровень"
