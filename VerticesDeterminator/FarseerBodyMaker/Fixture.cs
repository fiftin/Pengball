using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FarseerBodyMaker
{
    public class Fixture
    {
        private string name;

        public string Name
        {
            get { return name; }
        }

        public Fixture(string name)
        {
            this.name = name;
        }

        private List<Point> vertices = new List<Point>();
        public Point[] GetVertices()
        {
            return vertices.ToArray();
        }

        public void Clear()
        {
            vertices.Clear();
        }

        public void SetVertices(Point[] points)
        {
            Clear();
            vertices.AddRange(points);
        }


        public void RemoveVertex(int index)
        {
            vertices.RemoveAt(index);
        }

        public void AddVertex(Point point)
        {
            vertices.Add(point);
        }
    }
}
