using Microsoft.EntityFrameworkCore;

namespace RockBandsArchive.Data
{
    public class BandService
    {

        public async Task<List<Band>> GetBandlist()
        {
            var bands = new List<Band>();
            BandDbContext context = new BandDbContext();
            bands = context.Bands.Include(a => a.Genre).ToList();
            return await Task.FromResult(bands);
        }

        public async Task<List<Genre>> GetGenrelist()
        {
            var genres = new List<Genre>();
            BandDbContext context = new BandDbContext();
            genres = context.Genres.ToList();
            return await Task.FromResult(genres);
        }

        //add band
        public async Task AddBand(Band band)
        {

            using (var context = new BandDbContext())
            {
                await context.Bands.AddAsync(band);
                await context.SaveChangesAsync();
            }
        }
        public async Task AddGenre(Genre genre)
        {
            using (var context = new BandDbContext())
            {
                await context.Genres.AddAsync(genre); // Add the genre to the Genres table
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteBand(Band band)
        {
            using (var context = new BandDbContext())
            {
                context.Bands.Remove(band);
                await context.SaveChangesAsync();
            }
        }
        public async Task<Band> GetBandById(int id)
        {
            using (var context = new BandDbContext())
            {
                return await context.Bands.FindAsync(id);
            }
        }

        public async Task EditBand(Band editedBand)
        {
            using (var context = new BandDbContext())
            {
                // Check if the band with the given ID exists in the database
                var existingBand = await context.Bands.FindAsync(editedBand.BandId);

                if (existingBand != null)
                {
                    // Update the properties of the existing band with the new values
                    existingBand.Name = editedBand.Name;
                    existingBand.Origen = editedBand.Origen;
                    existingBand.GenreId = editedBand.GenreId;

                    // Save the changes to the database
                    await context.SaveChangesAsync();
                }
                else
                {
                    // Handle the case where the band with the given ID doesn't exist
                    // You can throw an exception or handle it according to your requirements
                }
            }
        }



    }
}
