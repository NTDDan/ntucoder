﻿namespace api.DTOs
{
    public class HasProblemDTO
    {
        public int ContestID { get; set; }
        public int ProblemID { get; set; }
        public int ProblemOrder { get; set; }
        public int Point { get; set; }

        public string ContestName { get; set; }
        public string ProblemName { get; set; }
    }
}
