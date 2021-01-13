using Netflix.Domain.Enum;
using System;

namespace Netflix.Domain.Entities
{
    public class Movie : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MovieStatus Status { get; set; }
        public long ViewedCount { get; set; }
        public long LikedCount { get; set; }
        public Guid CategoryId { get; set; }
        public MovieCategory Category { get; set; }

        public void Like()
        {
            LikedCount++;
        }

        public void UnLike()
        {
            LikedCount--;
        }

        public void SetStatus(MovieStatus movieStatus)
        {
            Status = movieStatus;
        }
    }
}
