using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.SteamStore
{
    public class StoreMovieModel
    {
        public uint Id { get; set; }
        
        public string Name { get; set; }
        
        public string Thumbnail { get; set; }
        
        public StoreWebmModel Webm { get; set; }
        
        public bool Highlight { get; set; }
    }
}
