﻿namespace Library.Domain;

public class Book
{
    public Guid Id { get; set; }
    public string ISBN { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Author { get; set; } = null!;
    public DateTime RentStart { get; set; }
    public DateTime RentEnd { get; set; }
}