﻿using Neptunee.BaseCleanArchitecture.BaseEntity;

namespace Domain.Entities;

public class Employee : User
{
    private Employee(){}

    public Employee(string fullName,
        string phoneNumber, DateTime? birthDate, string email,
        string imageUrl)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        UserName = Guid.NewGuid().ToString();
        ImageUrl = imageUrl;
        Email = email;
    }
    
    public void Modify(string fullName, string imageUrl,
        DateTime? birthDate, string email, string phoneNumber)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        ImageUrl = imageUrl;
        Email = email;
    }
    
    public string? ImageUrl { get; set; }

    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();   
}