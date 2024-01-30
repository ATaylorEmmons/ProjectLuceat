
using System.Text.RegularExpressions;

using Microsoft.Xna.Framework;


namespace Engine.SpriteManagement
{
    public class SpriteSheetData
    {
        public string TextureName = "Default";
        public List<string> BoundsData;

        public SpriteSheetData()
        {
            BoundsData = new List<string>();
        }

        public Dictionary<string, Rectangle> GetSpriteBounds()
        {
            Dictionary<string, Rectangle> retBounds = new Dictionary<string, Rectangle>();

            foreach (string bound in BoundsData)
            {
                //Remove white space and convert to int
                string[] d = Regex.Replace(bound, @"\s+", "").Split(",");

                Rectangle b = new Rectangle(
                                        int.Parse(d[1]), int.Parse(d[2]),
                                        int.Parse(d[3]), int.Parse(d[4])
                                       );

                retBounds.Add(d[0], b);
            }

            return retBounds;
        }
    }
}
