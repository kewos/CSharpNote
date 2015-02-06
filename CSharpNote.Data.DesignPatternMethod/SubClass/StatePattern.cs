using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    class Player
    {
        public Player()
        {
            State = new State10();
            Level = -1;
            Name = "AAA";
        }

        public IState State
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

        public void DoWork()
        {
            State.Show(this);
        }
    }

    interface IState
    {
        void Show(Player player);
    }

    class State10 : IState
    {
        public void Show(Player player)
        {
            if (player.Level <= 10)
            {
                Console.WriteLine("{0} LessThan {1}", player.Name, "Level 10");
            }
            else
            {
                player.State = new State30();
                player.DoWork();
            }
        }
    }

    class State30 : IState
    {
        public void Show(Player player)
        {
            if (player.Level <= 30 && player.Level > 10)
            {
                Console.WriteLine("{0} Between {1}", player.Name, "Level10 And Level30");
            }
            else
            {
                player.State = new State50();
                player.DoWork();
            }
        }
    }

    class State50 : IState
    {
        public void Show(Player player)
        {
            if (player.Level <= 50 && player.Level > 30)
            {
                Console.WriteLine("{0} Between {1}", player.Name, "Level50 And Level30");
            }
            else
            {
                player.State = new State99();
                player.DoWork();
            }
        }
    }

    class State99 : IState
    {
        public void Show(Player player)
        {
            if (player.Level > 50)
            {
                Console.WriteLine("{0} Greater Than {1}", player.Name, "Level50");
            }
        }
    }
}
