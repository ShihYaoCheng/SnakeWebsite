using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.Backstage
{
    public class Profile
    {

        public uint ProfileId { get; set; }
        public uint UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string? RealName { get; set; }
        public bool BeInterviewed { get; set; }
        public bool OpenAwardInfo { get; set; }
        public string? IdeaOfSnake { get; set; }
        public string? Recommendation { get; set; }
        public string? Link { get; set; }
        public char? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? SelfIntroduction { get; set; }
        public DateTime CreateTime { get; set; }


    }
}
