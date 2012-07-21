using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FarseerBodyMaker
{
    public class FixtureEventArgs : EventArgs
    {
        public FixtureEventArgs(Fixture fixture)
        {
            Fixture = fixture;
        }
        public Fixture Fixture { get; private set; }
    }
    public class Body
    {
        public void AddFixture(Fixture fixture)
        {
            fixtures.Add(fixture.Name, fixture);
            if (FixtureAdded != null)
                FixtureAdded(this, new FixtureEventArgs(fixture));
        }

        public void RemoveFixture(string name)
        {
            Fixture fixture;
            if (fixtures.TryGetValue(name, out fixture))
            {
                fixtures.Remove(name);
                if (FixtureRemoved != null)
                    FixtureRemoved(this, new FixtureEventArgs(fixture));
            }
        }

        public void Load(string fileName)
        {
        }

        public void Save(string fileName)
        {
        }

        private IDictionary<string,Fixture>  fixtures = new Dictionary<string,Fixture>();
        public Point? Center { get; set; }
        public IDictionary<string,Fixture>  Fixtures
        {
            get { return fixtures; }
            set { fixtures = value; }
        }

        public event EventHandler<FixtureEventArgs> FixtureAdded;
        public event EventHandler<FixtureEventArgs> FixtureRemoved;
    }
}
