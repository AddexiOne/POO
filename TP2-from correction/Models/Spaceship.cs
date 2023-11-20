using SpaceInvadersArmory;

namespace Models
{
    public abstract class Spaceship : IEquatable<Spaceship>, ISpaceship
    {
        public Guid Id { get; } = new Guid();
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public double MaxStructure { get; set; }
        public double MaxShield { get; set; }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool BelongsPlayer { get; }

        public virtual void TakeDamages(double damages)
        {
            CurrentShield -= damages;
            bool hasShield = CurrentShield > 0;
            if (!hasShield)
            {
                Structure += CurrentShield;
                CurrentShield = 0;
            }
        }

        public virtual void RepairShield(double repair)
        {
            CurrentShield += repair;
            if (CurrentShield > MaxShield)
            {
                CurrentShield = MaxShield;
            }
        }

        public virtual void ShootTarget(Spaceship target)
        {
            if (Weapons.Count <= 0) return;
            if (Weapons[0].IsReload)
            {
                Weapons[0].TimeBeforReload -= 1;
                if (Weapons[0].TimeBeforReload <= 0)
                {
                    Weapons[0].TimeBeforReload = Weapons[0].ReloadTime;
                }
            }
            else
            {
                target.TakeDamages(Weapons[0].Shoot());
            }
        }

        public virtual void ReloadWeapons()
        {
            throw new NotImplementedException();
        }

        public bool IsDestroyed
        {
            get => CurrentStructure <= 0;
        }

        public int MaxWeapons { get; } = 3;
        public List<SpaceInvadersArmory.Weapon> Weapons { get; } = new List<SpaceInvadersArmory.Weapon>();
        public double AverageDamages => (Weapons.Sum(x => x.MinDamage) + Weapons.Sum(x => x.MaxDamage)) / 2;

        public Spaceship(string name)
        {
            Name = name;
        }

        public void AddWeapon(SpaceInvadersArmory.Weapon weapon)
        {
            // test si l'arme provien bien de l'armurerie mais c'est quasiment impossible avec les visibilités utilisées
            if (!Armory.IsWeaponFromArmory(weapon)) { throw new ArmoryException(); }
            // évite de dépasser le nombre maximum d'arme sur le vaisseau
            if (Weapons.Count < MaxWeapons) { Weapons.Add(weapon); }
            else { throw new Exception(Name + " : Max Weapons on ship"); }
        }
        public void RemoveWeapon(SpaceInvadersArmory.Weapon oWeapon)
        {
            if (Weapons.Contains(oWeapon)) { Weapons.Remove(oWeapon); }
        }
        public void ClearWeapons()
        {
            Weapons.Clear();
        }

        public void ViewShip()
        {
            Console.WriteLine("===== INFOS VAISSEAU =====");
            Console.WriteLine("Nom : " + Name);
            Console.WriteLine("Points de vie : " + MaxStructure);
            Console.WriteLine("Bouclier : " + MaxShield);
            ViewWeapons();
            Console.WriteLine("Dommages moyens: " + AverageDamages );
            Console.WriteLine();
        }
        public void ViewWeapons()
        {
            foreach (var item in Weapons)
            {
                Console.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// Permet de construire un vaisseau par defaut avec une structure de 10 pts et 10 pts de bouclier
        /// Ajoute le maximum d'arme provenant au hasard de l'armurerie
        /// </summary>
        /// <returns>Un vaisseau par defaut</returns>
        public static Spaceship DefaultSpaceship()
        {
            Random rnd = new Random();
            Spaceship ship = new ViperMKII() { Name = "Viper MKII", MaxStructure = 10, MaxShield = 10 };
            while (ship.Weapons.Count < ship.MaxWeapons)
            {
                try {
                    ship.AddWeapon(Armory.CreatWeapon(Armory.Blueprints[rnd.Next(0, Armory.Blueprints.Count)]));
                } catch(Exception e) { Console.WriteLine(e.Message); }
            }
            try {
                ship.AddWeapon(Armory.CreatWeapon(Armory.Blueprints[rnd.Next(0, Armory.Blueprints.Count)]));
            } catch (Exception e) { Console.WriteLine(e.Message); }
            return ship;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Spaceship);
        }

        public bool Equals(Spaceship other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
