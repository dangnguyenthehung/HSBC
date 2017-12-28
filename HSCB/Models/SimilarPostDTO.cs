using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSCB.Models
{
    public class SimilarPostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public SimilarPostDTO()
        {
            
        }
        public SimilarPostDTO(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}