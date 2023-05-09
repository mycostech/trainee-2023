﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CandidateAPIApplication.Models
{
    public class CommentsScoresModel
    {
        [Key]
        public int CommentScoreId { get; set; }
        public int CandidateId { get; set; }
        public string? Comments { get; set; }
        public int Scores { get; set; }
    }
}
