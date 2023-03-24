using MagiVillaAPI.Dtos;

namespace MagiVillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> { 
            new VillaDTO { Id = 1, Name = "Hill Bottom"},
            new VillaDTO { Id = 2, Name = "My Best Villa House"}
            };
    }
}
