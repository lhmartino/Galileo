﻿using Flunt.Validations;

namespace GalileoAPI.Domain.Products;

public class Category : Entity
{    
    public string Name { get; private set; }    
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedDate = DateTime.Now;
        EditedDate = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Category>()
                   .IsNotNullOrEmpty(Name, "Name")
                   .IsGreaterOrEqualsThan(Name, 3, "Name")
                   .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
                   .IsNotNullOrEmpty(EditedBy, "EditedBy");

        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active)
    {
        Active = active;
        Name = name;

        Validate();


    }

}
