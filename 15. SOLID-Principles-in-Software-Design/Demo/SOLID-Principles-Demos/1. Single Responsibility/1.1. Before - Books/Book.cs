﻿namespace SingleResponsibilityBooksBefore
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Location { get; set; }

        // Otvariame stranicata i vrastame sadarjanieto na stranicata
        public string TurnPage(int page)
        {
            return "Current page";
        }
    }
}