using System.Security.Cryptography;
using Models;
using SpaceInvadersArmory;

namespace ConsoleGame
{
    public class SpaceInvaders
    {
        #region Patern singleton
        //implémentation thread safe du patern singleton
        private static readonly Lazy<SpaceInvaders> lazy =
        new Lazy<SpaceInvaders>(() => new SpaceInvaders());

        public static SpaceInvaders Instance { get { return lazy.Value; } }

        private SpaceInvaders() { Init(); }
        #endregion Patern singleton

        public List<Player> Players { get; } = new List<Player>();
        public List<Spaceship> Enemies { get; } = new List<Spaceship>();

        public List<Spaceship> Ships { get; } = new List<Spaceship>();

        private void Init()
        {
            Players.Add(new Player("MaXiMe", "haRlé", "Per6fleur"));

            Enemies.Add(new Dart());
            Enemies.Add(new B_Wings());
            Enemies.Add(new Rocinante());
            Enemies.Add(new ViperMKII());
            Enemies.Add(new F_18());
            Enemies.Add(new Tardis());

            Ships.Add(Players[0].BattleShip);
            Ships.AddRange(Enemies);


        }
        static void Main(string[] args)
        {
            Armory.ViewArmory();
            while (Instance.Players[0].BattleShip.IsDestroyed && Instance.Enemies.Count > 0)
            {
                PlayRound();
            }
        }

        static void PlayRound()
        {
            Console.WriteLine("=====            Round            =====");
            Instance.Ships.Clear();
            Instance.Ships.Add(Instance.Players[0].BattleShip);
            int aliveEnemies = 0;
            for (int i = 0; i < Instance.Enemies.Count; i++)
            {
                if (!Instance.Enemies[i].IsDestroyed)
                {
                    Instance.Ships.Add(Instance.Enemies[i]);
                    aliveEnemies++;
                    if (Instance.Enemies[i] is IAbility)
                    {
                        Console.WriteLine($"{Instance.Enemies[i].Name} utilise son pouvoir");
                        ((IAbility)Instance.Enemies[i]).UseAbility(Instance.Ships);
                    }
                }
                else {
                    Instance.Enemies.RemoveAt(i);
                }
            }
            // players has 1 chance of aliveEnemies + 1 to shoot
            if (RandomNumberGenerator.GetInt32(aliveEnemies + 1) == 0)
            {
                var enemy = Instance.Enemies[RandomNumberGenerator.GetInt32(Instance.Enemies.Count)];
                if (!enemy.IsDestroyed)
                {
                    Console.WriteLine($"{Instance.Players[0].BattleShip.Name} tire sur {enemy.Name}");
                    Instance.Players[0].BattleShip.ShootTarget(enemy);
                }

            }
            foreach (var enemy in Instance.Enemies)
            {
                if (!enemy.IsDestroyed)
                {
                    Console.WriteLine($"Enemy: {enemy.Name} tire sur {Instance.Players[0].BattleShip.Name}");
                    enemy.ShootTarget(Instance.Players[0].BattleShip);
                }
            }

            foreach (var ship in Instance.Ships)
            {
                if (!ship.IsDestroyed)
                {
                    Console.WriteLine($"{ship.Name} se répare");
                    ship.RepairShield(2);
                    Console.WriteLine($"{ship.Name} : {ship.CurrentStructure} PV, {ship.CurrentShield} Shield");
                }

            }


        }
    }
}
