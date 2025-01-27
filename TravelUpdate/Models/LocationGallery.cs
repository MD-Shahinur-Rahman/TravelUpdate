﻿namespace TravelUpdate.Models
{
    public class LocationGallery
    {
        public int LocationGalleryID { get; set; }
        public int GalleryID { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public string ImageCaption { get; set; }

        // Foreign Key
        public int LocationID { get; set; }
        public Location Location { get; set; }
    }

}