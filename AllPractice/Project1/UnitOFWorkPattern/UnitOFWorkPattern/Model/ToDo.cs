﻿namespace UnitOFWorkPattern.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDt { get; set; }
    }
}
