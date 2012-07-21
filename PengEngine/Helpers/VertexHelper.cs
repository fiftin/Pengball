using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PengEngine.Helpers
{
    public static class VertexHelper
    {
        public static List<Vector2> ParseVertices(System.IO.TextReader reader)
        {
            List<Vector2> vectices = new List<Vector2>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] s = line.Split(',', ';');
                if (s.Length != 2)
                    continue;
                float x, y;
                if (!float.TryParse(s[0].Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out x)
                    || !float.TryParse(s[1].Trim(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out y))
                {
                    continue;
                }
                vectices.Add(new Vector2(x, y));
            }
            return vectices;
        }

    }
}
