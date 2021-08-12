using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDeploymentApi.Models
{
    public class Info
    {
        public string CreatedAt { get; set; }

        public string Language { get; set; }

        public string Description { get; set; }

        public string ImageLocatedAt { get; set; }
        public string Title { get; set; }


        public Info(string createdAt, string language, string description, string imageLocatedAt, string title)
        {
            this.CreatedAt = createdAt;
            this.Description = description;
            this.Language = language;
            this.ImageLocatedAt = imageLocatedAt;
            this.Title = title;
        }
    }
}