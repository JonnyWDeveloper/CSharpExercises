using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn3
{
    internal abstract class Animal
    {
        private string name;
        private int age;
        private double weight;
        internal Animal(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public abstract void DoSound();

        public virtual string Stats()
        {
            string properties = $"{Name} {Age} {Weight} ";
            return properties;
        }
    }
    internal class Horse : Animal
    {
        private bool canSleepStandingUp;
        public Horse(string name, int age, double weight, bool canSleepStandingUp) : base(name, age, weight)
        {
            this.canSleepStandingUp = canSleepStandingUp;
        }

        public bool CanSleepStandingUp
        {
            get => canSleepStandingUp;
            set => canSleepStandingUp = value;
        }

        public override void DoSound()
        {
            Console.WriteLine("Horse sound: Neighing, snorting, blowing, squealing and roaring!");
        }
        public override string Stats()
        {
            string properties = base.Stats() + $"{CanSleepStandingUp}";
            return properties;
        }
    }
    internal class Dog : Animal
    {
        private bool canDetectMedicalIssues;
        public Dog(string name, int age, double weight, bool canDetectMedicalIssues) : base(name, age, weight)
        {
            CanDetectMedicalIssues = canDetectMedicalIssues;
        }

        public bool CanDetectMedicalIssues
        {
            get
            {
                return canDetectMedicalIssues;
            }
            set
            {
                canDetectMedicalIssues = value;
            }
        }

        public override void DoSound()
        {
            Console.WriteLine("Dog sound: Woof and bark!");

        }
        public string WalkTheDog()
        {
            return "The dog takes a lovely walk in the park.";
        }
       
        public override string Stats()
        {
            string properties = base.Stats() + $"{CanDetectMedicalIssues}";
            return properties;
        }
    }
    internal class Hedgehog : Animal
    {
        private int noOfSpikes;
        public Hedgehog(string name, int age, double weight, int noOfSpikes) : base(name, age, weight)
        {
            this.noOfSpikes = noOfSpikes;
        }
        public int NoOfSpikes
        {
            get
            {
                return noOfSpikes;
            }
            set
            {
                noOfSpikes = value;
            }
        }
        public override void DoSound()
        {
            Console.WriteLine("Hedgehog sound: Grunting Like a Pig!");
        }
        public override string Stats()
        {
            string properties = base.Stats() + $"{NoOfSpikes}";
            return properties;
        }
    }
    internal class Worm : Animal
    {
        private bool isPoisonous;
        public Worm(string name, int age, double weight, bool isPoisonous) : base(name, age, weight)
        {
            IsPoisonous = isPoisonous;
        }
        public bool IsPoisonous
        {
            get
            {
                return isPoisonous;
            }
            set
            {
                isPoisonous = value;
            }
        }

        public override void DoSound()
        {
            Console.WriteLine("Worm sound: Faint, airborne, sounds!");
        }
        public override string Stats()
        {
            string properties = base.Stats() + $"{IsPoisonous}";
            return properties;
        }
    }
    internal class Wolf : Animal
    {
        protected bool isWild;
        public Wolf(string name, int age, double weight, bool isWild) : base(name, age, weight)
        {
            IsWild = isWild;
        }

        public bool IsWild
        {
            get
            {
                return isWild;
            }
            set
            {
                isWild = value;
            }
        }

        public override void DoSound()
        {
            Console.WriteLine("Wolf sound: Barking, whimpering, growling, howling and in combinations!");
        }
        public override string Stats()
        {
            string properties = base.Stats() + $"{isWild}";
            return properties;
        }
    }
    internal class Bird : Animal
    {
        protected double wingSpan;

        public Bird(string name, int age, double weight, double wingSpan) : base(name, age, weight)
        {
            this.wingSpan = wingSpan;
        }

        public double WingSpan
        {
            get
            {
                return wingSpan;
            }
            set
            {
                wingSpan = value;
            }
        }

        public override void DoSound()
        {
            Console.WriteLine("Bird sound: birdie nam nam!");
        }
        public override string Stats()
        {
            string properties = base.Stats() + $"{WingSpan}";
            return properties;
        }
    }
    internal class Pelican : Bird
    {
        private bool endangered;
        public Pelican(string name, int age, double weight, double wingSpan, bool endangered) : base(name, age, weight, wingSpan)
        {
            this.endangered = endangered;
        }
        public bool Endangered
        {
            get
            {
                return endangered;
            }
            set
            {
                endangered = value;
            }
        }
        public override void DoSound()
        {
            Console.WriteLine("Pelican sound: Low grunt!");
        }
        public override string Stats()
        {
            string properties = base.Stats() + $"{WingSpan} {Endangered}";
            return properties;
        }
    }
    internal class Flamingo : Bird
    {
        private bool gregarious;
        public Flamingo(string name, int age, double weight, double wingSpan, bool gregarious) : base(name, age, weight, wingSpan)
        {
            this.gregarious = gregarious;
        }

        public bool Gregarious
        {
            get
            {
                return gregarious;
            }
            set
            {
                gregarious = value;
            }
        }

        public override void DoSound()
        {
            Console.WriteLine("Flamingo sound: Nasal honking to grunting or growling!");
        }
        public override string Stats()
        {
            string properties = base.Stats() + $"{WingSpan} {Gregarious}";
            return properties;
        }
    }
    internal class Swan : Bird
    {
        private bool loyal;
        public Swan(string name, int age, double weight, double wingSpan, bool loyal) : base(name, age, weight, wingSpan)
        {
            this.loyal = loyal;
        }

        public bool Loyal
        {
            get
            {
                return loyal;
            }
            set
            {
                loyal = value;
            }
        }

        public override void DoSound()
        {
            Console.WriteLine("Swan sound: Hoarse, muffled trumpet or bugle call!");
        }
        public override string Stats()
        {
            string properties = base.Stats() + $"{WingSpan} {Loyal}";
            return properties;
        }
    }
    internal class Wolfman : Wolf, IPerson
    {
        private bool canTalk;
        public Wolfman(string name, int age, double weight, bool isWild, bool canTalk) : base(name, age, weight, isWild)
        {
            this.canTalk = canTalk;
        }
        public bool CanTalk
        {
            get
            {
                return canTalk;
            }
            set
            {
                canTalk = value;
            }
        }
        public override string Stats()
        {
            string properties = base.Stats() + $" {isWild} {CanTalk}";
            return properties;
        }
        public void Talk()
        {
            Console.WriteLine("Wolfman talk: \nI am a Person who inherits from Wolf and implement IPerson!\n" +
                "If necessary I can even howl!\n");
        }
    }
}
