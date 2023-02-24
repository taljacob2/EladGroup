namespace EladGroup.Models.Customs.Joins
{
    public class StreetJoinCity
    {
        public int StreetId { get; set; }

        public string StreetName { get; set; }

        public int StreetPriority { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public int CityPriority { get; set; }
    }
}
