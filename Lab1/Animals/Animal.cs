using System;
using Lab1;

namespace Lab1
{
    public abstract class Animal
    {
        public string Name { get; }
        public bool IsAlive { get; private set; } = true;
        
        private int feedCount = 0;
        private DateTime lastFeed;
        private DateTime lastClean;
        
        public bool IsHappy { get; private set; } = false;

        protected Animal(string name)
        {
            Name = name;
            var now = CalendarService.Instance.CurrentTime;
            lastFeed = now;
            lastClean = now;
        }

        public event EventHandler<AnimalStateChangeArgs> StateChanged;
        public event EventHandler<AnimalDeathEventArgs> Died;

        public ActionResult Feed()
        {
            var now = CalendarService.Instance.CurrentTime;
            
            if (feedCount >= 5)
                return ActionResult.Fail("Too many feedings today");
            
            if ((now - lastFeed).TotalHours < 4.8)
                return ActionResult.Fail("Too early to feed");

            feedCount++;
            lastFeed = now;
            StateChanged?.Invoke(this, new AnimalStateChangeArgs(AnimalState.Eating));
            return ActionResult.Ok($"{Name} fed");
        }

        public ActionResult Clean()
        {
            lastClean = CalendarService.Instance.CurrentTime;
            UpdateHappiness();
            StateChanged?.Invoke(this, new AnimalStateChangeArgs(AnimalState.Happiness));
            return ActionResult.Ok($"{Name} cleaned");
        }

        public void SetWild()
        {
            // На волі тварина автоматично щаслива
            IsHappy = true;
        }

        private void UpdateHappiness()
        {
            var hoursSinceClean = (CalendarService.Instance.CurrentTime - lastClean).TotalHours;
            IsHappy = hoursSinceClean <= 24;
        }

        protected bool CanBeActive()
        {
            return (CalendarService.Instance.CurrentTime - lastFeed).TotalHours <= 8;
        }

        public void CheckLife()
        {
            if (!CanBeActive())
                Die(AnimalDeathReason.Hunger);
            
            UpdateHappiness();
        }

        protected void Die(AnimalDeathReason reason)
        {
            if (!IsAlive) return;
            IsAlive = false;
            Died?.Invoke(this, new AnimalDeathEventArgs(reason));
        }
    }
}