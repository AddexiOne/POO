using System;

namespace SpaceInvadersArmory
{
    public class Weapon : IWeapon, IEquatable<Weapon>
    {
        public Guid Id { get; } = new Guid();
        /// <summary>
        /// Le shéma utilisé pour créer l'arme
        /// </summary>
        public WeaponBlueprint Blueprint { get; }
        public string Name { get; set; }
        public EWeaponType Type { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage => (MinDamage + MaxDamage) / 2;
        double IWeapon.ReloadTime
        {
            get => ReloadTime;
            set => ReloadTime = (float)value;
        }

        public double TimeBeforReload { get; set; }
        public float ReloadTime { get; set; }
        public float TimeBeforeReloaded { get; set; }

        /// <summary>
        /// Constructeur avec une visibilité internal pour que seule l'armurerie puisse créer des armes.
        /// Par ce moyen on s'assure que toutes les armes proviennent l'armurerie
        /// </summary>
        /// <remarks>Exemple d'utilisation de la visibilité internal</remarks>
        public Weapon(WeaponBlueprint blueprint)
        {
            Blueprint = blueprint;
            Name = blueprint.Name;
            Type = blueprint.Type;
            MinDamage = blueprint.MinDamage;
            MaxDamage = blueprint.MaxDamage;
        }
   
        public override String ToString()
        {
            return Name + " : " + Type + " (" + MinDamage + "-" + MaxDamage + ")";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Weapon);
        }

        public bool Equals(Weapon other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        /// <summary>
        /// Compare les arme en fonction de leur shéma
        /// </summary>
        /// <param name="obj">l'objet à comparer</param>
        /// <returns>le resultat de la comparaison</returns>
        public bool EqualsBlueprint(object obj)
        {
            return Equals(obj as Weapon);
        }
        public bool EqualsBlueprint(Weapon other)
        {
            return other != null &&
                   Blueprint.Equals(other.Blueprint);
        }

        public bool IsReload { get; }
        double IWeapon.Shoot()
        {
            return Shoot();
        }

        public int Shoot()
        {
            if (TimeBeforeReloaded > 0)
            {
                return 0;
            }
            switch (Type)
            {
                case EWeaponType.Direct:
                    if (new Random().Next(0, 10) == 0)
                    {
                        TimeBeforeReloaded = ReloadTime;
                        return 0;
                    }
                    break;
                case EWeaponType.Explosive:
                    if (new Random().Next(0, 4) == 0)
                    {
                        TimeBeforeReloaded = ReloadTime * 2;
                        return (int)Math.Round(new Random().NextDouble() * (MaxDamage - MinDamage) + MinDamage) * 2;
                    }
                    break;
                case EWeaponType.Guided:
                    TimeBeforeReloaded = ReloadTime;
                    return (int)MinDamage;
            }
            return 0;
        }
    }
}
