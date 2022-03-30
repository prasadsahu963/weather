namespace Weather.ServiceLayer.ServiceModels
{
    public class LocationDisplayModel
    {
        public int Key { get; set; }

        public string LocalizedName { get; set; }

        public Location Country { get; set; }

        public Location AdministrativeArea { get; set; }
    }

    public class Location
    {
        public string LocalizedName { get; set; }
    }
}