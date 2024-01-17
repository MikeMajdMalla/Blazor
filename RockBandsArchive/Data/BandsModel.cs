namespace RockBandsArchive.Data
{
    
    public class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public string Origen  { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    } 

}
