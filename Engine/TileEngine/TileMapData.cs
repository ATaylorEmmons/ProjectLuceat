

using System.Text.RegularExpressions;


namespace Engine.TileEngine
{

    public class TileMapData
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public string TileTypes = "";


        public List<int> getTiles()
        {
            //Remove white space and convert to int
            string tilesRMWhiteSpace = Regex.Replace(TileTypes, @"\s+", "");

            return tilesRMWhiteSpace.Split(',').Select(int.Parse).ToList();
        }
    }
}
