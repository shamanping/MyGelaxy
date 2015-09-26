      //Ultron
      for (int i = 0; i < 1; i++)
      {
          var ultron = new Ultron(this);
          int positionY = ultron.Height + 90;
          int positionX = 300 + i * (ultron.Width + 50);

          ultron.Position = new Point(positionX, positionY);

          Actors.Add(ultron);
      }
