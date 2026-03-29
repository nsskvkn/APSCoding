using System;
using Lab_1;

namespace Lab_1
{
    public abstract class Animal
    {
        public string Name { get; }
        public bool IsAlive { get; private set; } = true;

        private int feedCount = 0;
        private DateTime lastFeed;

        protected Animal(string name)
        {
            Name = name;
            lastFeed = CalendarService.Instance.CurrentTime;
        }

        public event EventHandler<AnimalStateChangeArgs> StateChanged;
        public event EventHandler<AnimalDeathEventArgs> Died;

        public ActionResult Feed()
        {
            var now = CalendarService.Instance.CurrentTime;

            if (feedCount >= 5)
                return ActionResult.Fail("Too many feedings");

            if ((now - lastFeed).TotalHours < 4.8)
                return ActionResult.Fail("Too early to feed");

            feedCount++;
            lastFeed = now;

            StateChanged?.Invoke(this, new AnimalStateChangeArgs(AnimalState.Eating));

            return ActionResult.Ok($"{Name} fed");
        }

        public void Clean()
        {
            StateChanged?.Invoke(this, new AnimalStateChangeArgs(AnimalState.Happiness));
        }

        protected bool CanBeActive()
        {
            return (CalendarService.Instance.CurrentTime - lastFeed).TotalHours <= 8;
        }

        public void CheckLife()
        {
            if (!CanBeActive())
                Die(AnimalDeathReason.Hunger);
        }

        protected void Die(AnimalDeathReason reason)
        {
            if (!IsAlive) return;

            IsAlive = false;
            Died?.Invoke(this, new AnimalDeathEventArgs(reason));
        }
    }
}